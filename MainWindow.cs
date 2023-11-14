using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace Test_vs_glade_cs
{
    class MainWindow : Window
    {
        [UI] private Label _label1 = null;
        [UI] private Button _button1 = null;
        [UI] private ComboBox choix = null;
        [UI] private ListStore liststoreChoix = null;
        private string valChoisie = null;

        private int _counter;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            _button1.Clicked += Button1_Clicked;
            liststoreChoix.AppendValues("Angle");
            liststoreChoix.AppendValues("Longueur");
            liststoreChoix.AppendValues("Vitesse");
            liststoreChoix.AppendValues("Surface");
            liststoreChoix.AppendValues("Volume");
            liststoreChoix.AppendValues("Masse");
            liststoreChoix.AppendValues("Temps");
            liststoreChoix.AppendValues("Frequence");
            liststoreChoix.AppendValues("Temperature");
            liststoreChoix.AppendValues("Stockage Numerique");

            valChoisie = "Angle";

            choix.Changed += ChoixChanged;
        }
        private void ChoixChanged(object sender, EventArgs args)
        {
            ComboBox comboBox = (ComboBox)sender;
            TreeIter iter;
            if (comboBox.GetActiveIter(out iter))
            {
                valChoisie = (string)comboBox.Model.GetValue(iter, 0);
            }
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            // Application.Quit();
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            Convertisseur conv = new(valChoisie);
            conv.Show();
            // _counter++;
            // _label1.Text = "Hello World! This button has been clicked " + _counter + " time(s).";
        }
    }
}
