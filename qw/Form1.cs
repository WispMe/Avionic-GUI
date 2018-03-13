using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCComm;

using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Cameras;
using SharpGL.SceneGraph.Collections;
using SharpGL.SceneGraph.Primitives;
using SharpGL.Serialization;
using SharpGL.SceneGraph.Core;
using SharpGL.Enumerations;
using SharpGL.SceneGraph.Assets;

using System.IO;

using System.Diagnostics;
using System.Data.OleDb;

using ZedGraph;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;

using GMap;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;

namespace qw
{

	#region Public Enumerations
	public enum DataMode { Text, Hex }
	public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error };
	// Various colors for logging info
	//private Color[] LogMsgTypeColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };
	#endregion

	public partial class Form1 : Form
    {

        private SerialPort comPort = new SerialPort();
        CommunicationManager comm = new CommunicationManager();
        CommunicationManager commAT = new CommunicationManager();
        static double xTimeStamp = 0;

		static GUI_settings gui_settings;

		//Routes on Map
        static GMapRoute GMRouteFlightPath;
        //static GMapRoute GMRouteMission;

        //Map Overlays
        static GMapOverlay GMOverlayFlightPath;// static so can update from gcs
        static GMapOverlay GMOverlayWaypoints;
        static GMapOverlay GMOverlayMission;
        static GMapOverlay GMOverlayLiveData;
        //static GMapOverlay GMOverlayPOI;

        static GMapProvider[] mapProviders;
        //static PointLatLng copterPos = new PointLatLng(47.402489, 19.071558);       //Just the corrds of my flying place
        static PointLatLng copterPos = new PointLatLng(-6.976916, 107.630210);
        //static PointLatLng copterPos;
        static bool isMouseDown = false;
        static bool isMouseDraging = false;

        static bool bPosholdRecorded = false;
        static bool bHomeRecorded = false;

        // markers
        GMarkerGoogle currentMarker;
        GMapMarkerRect CurentRectMarker = null;
        GMapMarker center;
        //GMapMarker markerGoToClick = new GMarkerGoogle(new PointLatLng(0.0, 0.0), GMarkerGoogleType.lightblue);

        List<PointLatLng> points = new List<PointLatLng>();

        PointLatLng GPS_pos, GPS_pos_old;
        PointLatLng Home;
        PointLatLng end;
        PointLatLng start;

        //static GMapControl gmap ;



        int countx = 15;

        bool antena = false;



		string header, Accx = "0", Accy = "0", Accz, Gyrox = "0", Gyroy = "0", Gyroz = "0";

        public Form1()
        {
            InitializeComponent();

          //  timer1.Tick += new EventHandler(timer1_Tick);
			SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
			gl.Enable(OpenGL.GL_TEXTURE_2D);

			try
			{
				System.Net.IPHostEntry e =
					 System.Net.Dns.GetHostEntry("www.google.com");
			}
			catch
			{
				gmap.Manager.Mode = AccessMode.CacheOnly;
				MessageBox.Show("No internet connection avaible, going to CacheOnly mode.",
				"GMap.NET - Demo.WindowsForms", MessageBoxButtons.OK,
				MessageBoxIcon.Warning);
			}


			gmap.MinZoom = 1;
			gmap.MaxZoom = 50;
			gmap.CacheLocation = Path.GetDirectoryName(Application.ExecutablePath) + "/mapcache/";
			gmap.Position = new PointLatLng(GPS_pos.Lat, GPS_pos.Lng);

			mapProviders = new GMapProvider[7];


			gmap.MapProvider = GMapProviders.GoogleMap;
			mapProviders[0] = GMapProviders.BingHybridMap;
			mapProviders[1] = GMapProviders.BingSatelliteMap;
			mapProviders[2] = GMapProviders.GoogleSatelliteMap;
			mapProviders[3] = GMapProviders.GoogleHybridMap;
			mapProviders[4] = GMapProviders.OviSatelliteMap;
			mapProviders[5] = GMapProviders.OviHybridMap;

			//gmap.OnPositionChanged += new PositionChanged(gmap_OnPositionChanged);

			for (int i = 0; i < 6; i++)
			{
				comboBox3.Items.Add(mapProviders[i]);
			}

			// map events

			gmap.OnPositionChanged += new PositionChanged(gmap_OnCurrentPositionChanged);
			//gmap.OnMarkerClick += new MarkerClick(gmap_OnMarkerClick);
			//gmap.OnMapZoomChanged += new MapZoomChanged(gmap_OnMapZoomChanged);
			gmap.MouseMove += new MouseEventHandler(gmap_MouseMove);
			gmap.MouseDown += new MouseEventHandler(gmap_MouseDown);
			gmap.MouseUp += new MouseEventHandler(gmap_MouseUp);
			gmap.OnMarkerEnter += new MarkerEnter(gmap_OnMarkerEnter);
			gmap.OnMarkerLeave += new MarkerLeave(gmap_OnMarkerLeave);

			currentMarker = new GMarkerGoogle(gmap.Position, GMarkerGoogleType.red);
			gmap.MapScaleInfoEnabled = true;

			gmap.ForceDoubleBuffer = true;
			gmap.Manager.Mode = AccessMode.ServerAndCache;

			gmap.Position = copterPos;

			Pen penRoute = new Pen(Color.Yellow, 3);
			Pen penScale = new Pen(Color.Blue, 3);

			gmap.ScalePen = penScale;

			GMOverlayFlightPath = new GMapOverlay("flightpath");
			gmap.Overlays.Add(GMOverlayFlightPath);

			GMOverlayMission = new GMapOverlay("missionroute");
			gmap.Overlays.Add(GMOverlayMission);

			GMOverlayWaypoints = new GMapOverlay("waypoints");
			gmap.Overlays.Add(GMOverlayWaypoints);


			GMOverlayLiveData = new GMapOverlay("livedata");
			gmap.Overlays.Add(GMOverlayLiveData);

			GMOverlayLiveData.Markers.Clear();
			GMOverlayLiveData.Markers.Add(new GMapMarkerCopter(copterPos, 0, 0, 0));

			GMRouteFlightPath = new GMapRoute(points, "flightpath");
			GMRouteFlightPath.Stroke = penRoute;
			GMOverlayFlightPath.Routes.Add(GMRouteFlightPath);

			center = new GMarkerGoogle(gmap.Position, GMarkerGoogleType.blue_dot);
			//center = new GMapMarkerCross(gmap.Position);

			gmap.Invalidate(false);

			timer1.Tick += new EventHandler(timer1_Tick);

		}

        private void button5_Click(object sender, EventArgs e)
        {
            comm.WriteData("1");
            timer1.Interval = 100;
            timer1.Enabled = true;
            timer1.Start();
            //DiscardInBuffer();
            comm.gambar = 0;
            timer1.Tick += new EventHandler(FastTimer);
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string[] port = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            foreach (String sambung in port)
            {
                comboBox1.Items.Add(sambung);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (comm.isOpen() == true)
            {
                System.Threading.Thread.Sleep(100);
                comm.ClosePort();
            }
            else
            {
                if (comboBox1.Text == "") { return; }
                comm.Parity = "None";
                comm.StopBits = "One";
                comm.DataBits = "8";
                comm.BaudRate = comboBox2.Text;
                comm.DisplayWindow = richTextBox1;
                comm.PortName = comboBox1.Text;
                comm.OpenPort();

				button1.Enabled = false;
				button2.Enabled = true;
			}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Dispose();
            richTextBox1.Enabled = false;

            button1.Enabled = true;
            button2.Enabled = true;
        }



		Texture texture = new Texture();

		private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
		{

		}

		private void importPolygonToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//  Show a file open dialog.
			OpenFileDialog openDialog = new OpenFileDialog();
			openDialog.Filter = SerializationEngine.Instance.Filter;
			if (openDialog.ShowDialog() == DialogResult.OK)
			{
				Scene scene = SerializationEngine.Instance.LoadScene(openDialog.FileName);
				if (scene != null)
				{
					foreach (var polygon in scene.SceneContainer.Traverse<Polygon>())
					{
						//  Get the bounds of the polygon.
						BoundingVolume boundingVolume = polygon.BoundingVolume;
						float[] extent = new float[3];
						polygon.BoundingVolume.GetBoundDimensions(out extent[0], out extent[1], out extent[2]);

						//  Get the max extent.
						float maxExtent = extent.Max();

						//  Scale so that we are at most 10 units in size.
						float scaleFactor = maxExtent > 10 ? 10.0f / maxExtent : 1;
						polygon.Transformation.ScaleX = scaleFactor;
						polygon.Transformation.ScaleY = scaleFactor;
						polygon.Transformation.ScaleZ = scaleFactor;
						polygon.Freeze(openGLControl1.OpenGL);
						polygons.Add(polygon);
					}
				}
			}
		}

		private void importTextureToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//OpenFileDialog openFileDialog1 = new OpenFileDialog();

			//  Show a file open dialog.
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				//  Destroy the existing texture.
				texture.Destroy(openGLControl1.OpenGL);

				//  Create a new texture.
				texture.Create(openGLControl1.OpenGL, openFileDialog1.FileName);

				//  Redraw.
				openGLControl1.Invalidate();
			}
		}

		private void clearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
			polygons.Clear();
			texture.Destroy(gl);
		}

		private void freezeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (var poly in polygons)
				poly.Freeze(openGLControl1.OpenGL);
		}

		private void unfreezeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (var poly in polygons)
				poly.Unfreeze(openGLControl1.OpenGL);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void wireframeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			wireframeToolStripMenuItem.Checked = true;
			solidToolStripMenuItem.Checked = false;
			lighterToolStripMenuItem.Checked = false;
			openGLControl1.OpenGL.PolygonMode(FaceMode.FrontAndBack, PolygonMode.Lines);
			openGLControl1.OpenGL.Disable(OpenGL.GL_LIGHTING);
		}

		private void solidToolStripMenuItem_Click(object sender, EventArgs e)
		{
			wireframeToolStripMenuItem.Checked = false;
			solidToolStripMenuItem.Checked = true;
			lighterToolStripMenuItem.Checked = false;
			openGLControl1.OpenGL.PolygonMode(FaceMode.FrontAndBack, PolygonMode.Filled);
			openGLControl1.OpenGL.Disable(OpenGL.GL_LIGHTING);
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			//gmap.MapProvider = GMapProviders.GoogleSatelliteMap;
			gmap.MapProvider = (GMapProvider)comboBox3.SelectedItem;
			gmap.MinZoom = 5;
			gmap.MaxZoom = 20;
			gmap.Zoom = 18;
			gmap.Invalidate(false);
			gui_settings.iMapProviderSelectedIndex = comboBox3.SelectedIndex;
			//gui_settings.save_to_xml(sGuiSettingsFilename);


			this.Cursor = Cursors.Default;
		}

		private void openGLControl1_OpenGLDraw(object sender, PaintEventArgs e)
		{

			//  The texture identifier.
			/*Texture texture = new Texture(); */

			//  Get the OpenGL object, for quick access.
			SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

			//  Clear and load the identity.
			gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
			gl.LoadIdentity();

			//  Bind the texture.
			texture.Bind(gl);

			//  View from a bit away the y axis and a few units above the ground.
			gl.LookAt(-10, -15, 0, 0, 0, 0, 0, 1, 0);


			//  Rotate the objects every cycle.
			// gl.Rotate(rotate, 0.0f, 0.0f, 1.0f);
			//gl.Rotate(float.Parse(data_r), float.Parse(data_p), float.Parse(data_h));

			//  Move the objects down a bit so that they fit in the screen better.
			gl.Translate(0, 0, 0);

			//  Draw every polygon in the collection.
			foreach (Polygon polygon in polygons)
			{
				polygon.PushObjectSpace(gl);
				polygon.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
				polygon.PopObjectSpace(gl);
			}
			//  Rotate a bit more each cycle.
			rotate += 1.0f;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			RectLatLng area = gmap.SelectedArea;
			if (area.IsEmpty)
			{
				DialogResult res = MessageBox.Show("No ripp area defined, ripp displayed on screen?", "Rip", MessageBoxButtons.YesNo);
				if (res == DialogResult.Yes)
				{
					area = gmap.ViewArea;
				}

			}

			if (!area.IsEmpty)
			{
				DialogResult res = MessageBox.Show("Ready ripp at Zoom = " + (int)gmap.Zoom + " ?", "GMap.NET", MessageBoxButtons.YesNo);

				for (int i = 1; i <= gmap.MaxZoom; i++)
				{
					if (res == DialogResult.Yes)
					{
						TilePrefetcher obj = new TilePrefetcher();
						obj.ShowCompleteMessage = false;
						obj.Start(area, i, gmap.MapProvider, 100, 0);

					}
					else if (res == DialogResult.No)
					{
						continue;
					}
					else if (res == DialogResult.Cancel)
					{
						break;
					}
				}
			}
			else
			{
				//MessageBox.Show("Select map area holding ALT", "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void button4_Click(object sender, EventArgs e)
        {
            comm.WriteData("2");
            timer1.Interval = 100;
            timer1.Enabled = true;
            timer1.Start();
            //DiscardInBuffer();
            comm.gambar = 0;
            timer1.Tick += new EventHandler(FastTimer);
        }

		private void Form1_Load_1(object sender, EventArgs e)
		{
			GraphPane myPane = zedGraphControl1.GraphPane;

			Lax = new RollingPointPairList(300);
			Kax = myPane.AddCurve("acc_roll", Lax, Color.Pink, SymbolType.None);
			Lay = new RollingPointPairList(300);
			Kay = myPane.AddCurve("acc_roll", Lay, Color.Blue, SymbolType.None);
			Laz = new RollingPointPairList(300);
			Kaz = myPane.AddCurve("acc_roll", Laz, Color.Purple, SymbolType.None);
			myPane.XAxis.Scale.Min = 0;
			myPane.XAxis.Scale.Max = 30;
			myPane.XAxis.Scale.MinorStep = 1;
			myPane.XAxis.Scale.MajorStep = 5;
			zedGraphControl1.AxisChange();

		}



		string[] data;

        public delegate void myDelegate();

        private void UpdateData()
        {
            richTextBox1.Invoke(new EventHandler(delegate
            {
                textBox1.Text = header;
                textBox2.Text = Accx;
                textBox3.Text = Accy;
                textBox4.Text = Accz;
                textBox5.Text = Gyrox;
                textBox6.Text = Gyroy;
				textBox7.Text = Gyroz;
				textBox9.Text = lat;
				textBox10.Text = lon;

            }));
            richTextBox1.ScrollToCaret();
            xTimeStamp = xTimeStamp + 1;

			foreach (Polygon polygon in polygons)
			{
				polygon.Transformation.RotateX = h;
				polygon.Transformation.RotateY = r;
				polygon.Transformation.RotateZ = p;
			}


			airSpeedIndicatorInstrumentControl1.SetAirSpeedIndicatorParameters(int.Parse(Gyrox));
			altimeterInstrumentControl1.SetAlimeterParameters(int.Parse(Gyrox));
			attitudeIndicatorInstrumentControl1.SetAttitudeIndicatorParameters(Convert.ToDouble(Gyrox), Convert.ToDouble(Gyroy));
			turnCoordinatorInstrumentControl1.SetTurnCoordinatorParameters(float.Parse(Accx), float.Parse(Accy));
			headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters(int.Parse(Accx));
			verticalSpeedIndicatorInstrumentControl1.SetVerticalSpeedIndicatorParameters(int.Parse(Accy));

		}


        private void Form1_Load(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;

            Lax = new RollingPointPairList(300);
            Kax = myPane.AddCurve("acc_roll", Lax, Color.Pink, SymbolType.None);
            Lay = new RollingPointPairList(300);
            Kay = myPane.AddCurve("acc_roll", Lay, Color.Blue, SymbolType.None);
            Laz = new RollingPointPairList(300);
            Kaz = myPane.AddCurve("acc_roll", Laz, Color.Purple, SymbolType.None);
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 30;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
            zedGraphControl1.AxisChange();

			gui_settings = new GUI_settings();

			
			comboBox3.SelectedIndex = gui_settings.iMapProviderSelectedIndex;
			gmap.MapProvider = mapProviders[gui_settings.iMapProviderSelectedIndex];
			gmap.Zoom = 18;
			gmap.Invalidate(false);

			int w = gmap.Size.Width;
			gmap.Width = w + 1;
			gmap.Width = w;
			gmap.ShowCenter = false;
		}

		public class GUI_settings
		{
			public int iMapProviderSelectedIndex { get; set; }
			public GUI_settings()
			{
				iMapProviderSelectedIndex = 1;  //Bing Map
			}
		}

		public class GMapMarkerRect : GMapMarker
		{
			public Pen Pen = new Pen(Brushes.White, 2);

			public Color Color { get { return Pen.Color; } set { Pen.Color = value; } }
			public GMapMarker InnerMarker;
			public int wprad = 0;
			public GMapControl gmap;

			public GMapMarkerRect(PointLatLng p)
				: base(p)
			{
				Pen.DashStyle = DashStyle.Dash;

				Size = new System.Drawing.Size(50, 50);
				Offset = new System.Drawing.Point(-Size.Width / 2, -Size.Height / 2 - 20);
			}
			public override void OnRender(Graphics g)
			{
				base.OnRender(g);
				if (wprad == 0 || gmap == null)
					return;
				if (Pen.Color == Color.Blue)
					Pen.Color = Color.White;
				double width = (gmap.MapProvider.Projection.GetDistance(gmap.FromLocalToLatLng(0, 0), gmap.FromLocalToLatLng(gmap.Width, 0)) * 1000.0);
				double height = (gmap.MapProvider.Projection.GetDistance(gmap.FromLocalToLatLng(0, 0), gmap.FromLocalToLatLng(gmap.Height, 0)) * 1000.0);
				double m2pixelwidth = gmap.Width / width;
				double m2pixelheight = gmap.Height / height;

				GPoint loc = new GPoint((int)(LocalPosition.X - (m2pixelwidth * wprad * 2)), LocalPosition.Y);
				g.DrawArc(Pen, new System.Drawing.Rectangle((int)(LocalPosition.X - Offset.X - (Math.Abs(loc.X - LocalPosition.X) / 2)), (int)(LocalPosition.Y - Offset.Y - Math.Abs(loc.X - LocalPosition.X) / 2), (int)(Math.Abs(loc.X - LocalPosition.X)), (int)(Math.Abs(loc.X - LocalPosition.X))), 0, 360);
			}
		}

		public class GMapMarkerCopter : GMapMarker
		{
			const float rad2deg = (float)(180 / Math.PI);
			const float deg2rad = (float)(1.0 / rad2deg);

			//static readonly System.Drawing.Size SizeSt = new System.Drawing.Size(global::my_GUI.Properties.Resources.LongNeedleAltimeter.Width, global::my_GUI.Properties.Resources.LongNeedleAltimeter.Height);
			float heading = 0;
			float cog = -1;
			float target = -1;
			//byte coptertype;

			//public GMapMarkerCopter(PointLatLng p, float heading, float cog, float target, byte coptertype)
			public GMapMarkerCopter(PointLatLng p, float heading, float cog, float target)
				: base(p)
			{
				this.heading = heading;
				this.cog = cog;
				this.target = target;
				//this.coptertype = coptertype;
				//Size = SizeSt;
			}

			public override void OnRender(Graphics g)
			{
				System.Drawing.Drawing2D.Matrix temp = g.Transform;
				g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

				//Image pic = global::my_GUI.Properties.Resources.LongNeedleAltimeter;


				int length = 100;
				// anti NaN
				g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float)Math.Cos((heading - 90) * deg2rad) * length, (float)Math.Sin((heading - 90) * deg2rad) * length);
				//g.DrawLine(new Pen(Color.Black, 2), 0.0f, 0.0f, (float)Math.Cos((cog - 90) * deg2rad) * length, (float)Math.Sin((cog - 90) * deg2rad) * length);
				g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float)Math.Cos((target - 90) * deg2rad) * length, (float)Math.Sin((target - 90) * deg2rad) * length);
				// anti NaN
				g.RotateTransform(heading);
				//g.DrawImageUnscaled(pic, pic.Width / -2, pic.Height / -2);
				g.Transform = temp;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateData();
        }

        static LineItem Kax, Kay, Kaz;
        static RollingPointPairList Lax, Lay, Laz;

		float x, y, z, r, p, h;

		float rotate = 0;

		//  A set of polygons to draw.
		List<Polygon> polygons = new List<Polygon>();

		int yaws, air, head;
		string ik, lala, droll, dpitch, dyaw, dx, dy, dz, dalti, dsuhu, dtekan, lat, lon, line;
		double roll, pitch, yaw, suhu, alti, tekan, bearing = 000.0;

		private void FastTimer(object sender, EventArgs myEventArgs)
		{
			string[] tempArray = comm.DisplayWindow.Lines;
			string line = tempArray[tempArray.Length - 2];
			if (line == "") return;

			data = Regex.Split(line, " ");
			header = data[0];
			if (comm.gambar == 0)
			{
				if (header == "005" && data.Length == 13)
				{
					header = data[0];
					Accx = data[1];
					Accy = data[2];
					Accz = data[3];
					Gyrox = data[4];
					Gyroy = data[5];
					Gyroz = data[6];
					lat = data[11];
					lon = data[12];

					ik = Convert.ToString(GPS_pos);
					textBox8.Text = ik;


					yaws = int.Parse(data[11]);

					GPS_pos.Lat = Convert.ToDouble(lat);
					GPS_pos.Lng = Convert.ToDouble(lon);

					GMRouteFlightPath.Points.Add(GPS_pos);

					if (270.0 > bearing && bearing >= 180.0) { bearing = 180; }
					else if (270 <= bearing && bearing < 360) { bearing = 0; }

					gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
					GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;

					GMOverlayLiveData.Markers.Clear();
					gmap.Position = GPS_pos;
					//GMOverlayLiveData.Markers.Add(new GMapMarkerCopter(GPS_pos, float.Parse(dyaw), 0, 0));
					//GMOverlayLiveData.Markers.Add(new GMapMarkerLain(copterPos, 0, 0, 0));
					gmap.Invalidate(false);

					double jarak = gmap.MapProvider.Projection.GetDistance(copterPos, GPS_pos);
					jarak = jarak * 1000; //convert jadi meter

					double speed = jarak * 10;
					double sudut = Math.Atan2(Convert.ToDouble(dalti), jarak);
					//int elevasi = Convert.ToInt32(sudut);

					//richTextBox1.BeginInvoke(new myDelegate(updateData));

					if (antena)
					{
						//commAT.WriteData("P"+)
					}

					label1.Text = Convert.ToString(line.Length);

					r = float.Parse(data[9]);
					p = float.Parse(data[10]);
					h = float.Parse(data[11]);

					Lax.Add(xTimeStamp, Convert.ToDouble(data[1]));
					Lay.Add(xTimeStamp, Convert.ToDouble(data[2]));
					Laz.Add(xTimeStamp, Convert.ToDouble(data[3]));

					xTimeStamp = xTimeStamp + 1;

					Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
					if (xTimeStamp > xScale.Max - xScale.MajorStep)
					{
						xScale.Max = xTimeStamp + xScale.MajorStep;
						xScale.Min = xScale.Max - 30.0;

					}
					zedGraphControl1.AxisChange();
					zedGraphControl1.Invalidate();
				}
			}
		}

		public class GMapMarkerLain : GMapMarker
		{
			const float rad2deg = (float)(180 / Math.PI);
			const float deg2rad = (float)(1.0 / rad2deg);

			//static readonly System.Drawing.Size SizeSt = new System.Drawing.Size(global::my_GUI.Properties.Resources.home.Width, global::my_GUI.Properties.Resources.home.Height);
			float heading = 0;
			float cog = -1;
			float target = -1;

			public GMapMarkerLain(PointLatLng p, float heading, float cog, float target)
				: base(p)
			{
				this.heading = heading;
				this.cog = cog;
				this.target = target;
				//Size = SizeSt;
			}
			public override void OnRender(Graphics g)
			{
				System.Drawing.Drawing2D.Matrix temp = g.Transform;
				g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

				//g.DrawImageUnscaled(p)
				g.Transform = temp;
			}
		}

		void gmap_OnCurrentPositionChanged(PointLatLng point)
		{
			if (point.Lat > 90) { point.Lat = 90; }
			if (point.Lat < 90) { point.Lat = -90; }
			if (point.Lng > 180) { point.Lng = 180; }
			if (point.Lng < -180) { point.Lng = -180; }
			center.Position = point;
		}

		void gmap_OnMarkerLeave(GMapMarker item)
		{
			if (!isMouseDown)
			{
				if (item is GMapMarkerRect)
				{
					CurentRectMarker = null;
					GMapMarkerRect rc = item as GMapMarkerRect;
					rc.Pen.Color = Color.Blue;
					gmap.Invalidate(false);
				}
			}
		}

		void gmap_OnMarkerEnter(GMapMarker item)
		{
			if (!isMouseDown)
			{
				if (item is GMapMarkerRect)
				{
					GMapMarkerRect rc = item as GMapMarkerRect;
					rc.Pen.Color = Color.Red;
					gmap.Invalidate(false);

					CurentRectMarker = rc;
				}
			}
		}

		void gmap_MouseUp(object sender, MouseEventArgs e)
		{
			end = gmap.FromLocalToLatLng(e.X, e.Y);

			if (isMouseDown) // mouse down on some other object and dragged to here.
			{
				if (e.Button == MouseButtons.Left)
				{
					isMouseDown = false;
				}
				if (!isMouseDraging)
				{
					if (CurentRectMarker != null)
					{
						// cant add WP in existing rect
					}
					else
					{
						//addWP("WAYPOINT", 0, currentMarker.Position.Lat, currentMarker.Position.Lng, iDefAlt);
					}
				}
				else
				{
					if (CurentRectMarker != null)
					{
						//update existing point in datagrid
					}
				}
			}
			if (comm.isOpen() == true) timer1.Start();
			isMouseDraging = false;
		}

		void gmap_MouseDown(object sender, MouseEventArgs e)
		{
			start = gmap.FromLocalToLatLng(e.X, e.Y);

			if (e.Button == MouseButtons.Left && Control.ModifierKeys != Keys.Alt)
			{
				isMouseDown = true;
				isMouseDraging = false;

				if (currentMarker.IsVisible)
				{
					currentMarker.Position = gmap.FromLocalToLatLng(e.X, e.Y);
				}
			}
		}

		// move current marker with left holding
		void gmap_MouseMove(object sender, MouseEventArgs e)
		{

			PointLatLng point = gmap.FromLocalToLatLng(e.X, e.Y);

			currentMarker.Position = point;
			label3.Text = "Lat:" + String.Format("{0:0.000000}", point.Lat) + " Lon:" + String.Format("{0:0.000000}", point.Lng);

			if (!isMouseDown)
			{

			}


			//draging
			if (e.Button == MouseButtons.Left && isMouseDown)
			{
				isMouseDraging = true;
				if (CurentRectMarker == null) // left click pan
				{
					double latdif = start.Lat - point.Lat;
					double lngdif = start.Lng - point.Lng;
					gmap.Position = new PointLatLng(center.Position.Lat + latdif, center.Position.Lng + lngdif);
				}
				else
				{
					if (comm.isOpen() == true) timer1.Stop();
					PointLatLng pnew = gmap.FromLocalToLatLng(e.X, e.Y);
					if (currentMarker.IsVisible)
					{
						currentMarker.Position = pnew;
					}
					CurentRectMarker.Position = pnew;

					if (CurentRectMarker.InnerMarker != null)
					{
						CurentRectMarker.InnerMarker.Position = pnew;
						GPS_pos = pnew;
					}
				}
			}
		}

	}
}
