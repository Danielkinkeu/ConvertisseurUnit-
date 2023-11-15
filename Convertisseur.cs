using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Test_vs_glade_cs
{
    class Convertisseur : Window
    {
        [UI] private Label valeuri = null;
        [UI] private Label valeurf = null;
        [UI] private ComboBox from = null;
        [UI] private ComboBox to = null;
        [UI] private ListStore liststore1 = null;
        [UI] private ListStore liststore2 = null;
        [UI] private Entry valeur = null;
        private double v1 = 0;
        private double v2 = 0;
        
        private string init;
        private string final;
        private Unites initUnit;
        private Unites finalUnit;
        private string valChoisie;
        private  List<Unites> unites = new List<Unites>();

        public Convertisseur() : this(new Builder("Convertisseur.glade")) { }
        public Convertisseur(string valChoisie) : this(new Builder("Convertisseur.glade")) {
           
            // Les Angles

            Unites degre = new Unites("angles", "Degres", 1, true);
            unites.Add(degre);
            Unites radian = new Unites("angles", "Radians", 0.0175);
            unites.Add(radian);
            Unites grade = new Unites("angles", "Grades", 1.1111);
            unites.Add(grade);

            // Les surfaces
            Unites hectares = new Unites("surfaces", "Hectares", 1, true);
            unites.Add(hectares);
            Unites acres = new Unites("surfaces", "Acres", 2.4711, false);
            unites.Add(acres);
            Unites racineC = new Unites("surfaces", "Racine carree", 107639.1042, false);
            unites.Add(racineC);
            Unites metresC = new Unites("surfaces", "Metres carrees", 10000, false);
            unites.Add(metresC);
            Unites centimetresC = new Unites("surfaces", "Centimetres carrees", Math.Pow(10,8));
            unites.Add(centimetresC);

            // Les Volumes
            Unites metreC = new Unites("volumes", "Litres", 1, true);
            unites.Add(metreC);
            Unites mc = new Unites("volumes", "Metre cube", 0.001);
            unites.Add(mc);
            Unites galUS = new Unites("volumes", "Gallons US", 0.2642);
            unites.Add(galUS);
            Unites mill = new Unites("volumes", "Millilitres", 1000);
            unites.Add(mill);
            Unites mcl = new Unites("volumes", "Microlitres", Math.Pow(10,8));
            unites.Add(mcl);

            // Les masses
            Unites kGramme = new Unites("masses", "Kilogrammes", 1, true);
            unites.Add(kGramme);
            Unites tnn = new Unites("masses", "Tonnes", 0.001);
            unites.Add(tnn);
            Unites liv = new Unites("masses", "Livres", 2.2046);
            unites.Add(liv);
            Unites onc = new Unites("masses", "Onces", 35.274);
            unites.Add(onc);
            Unites g = new Unites("masses", "Grammes", 1000);
            unites.Add(g);

            // Le temps
            Unites jour = new Unites("temps", "Jours", 1, true);
            unites.Add(jour);
            Unites hr = new Unites("temps", "Heures", 24);
            unites.Add(hr);
            Unites mmn = new Unites("temps", "Minutes", 1440);
            unites.Add(mmn);
            Unites s = new Unites("temps", "Secondes", 86400);
            unites.Add(s);
            Unites mlls = new Unites("temps", "Millisecondes", 8.64 * Math.Pow(10,7));
            unites.Add(mlls);

            // Les Vitesses
            Unites mparS = new Unites("vitesses", "Metres par seconde", 1, true);
            unites.Add(mparS);
            Unites kmph = new Unites("vitesses", "Kilometres par heure", 3.6);
            unites.Add(kmph);
            Unites milleph = new Unites("vitesses", "Milles par heure", 2.2369);
            unites.Add(milleph);
            Unites pps = new Unites("vitesses", "Pieds par seconde", 3.2808);
            unites.Add(pps);
            Unites noeud = new Unites("vitesses", "Noeuds", 1.9438);
            unites.Add(noeud);

            // Les Longueurs
            Unites mlm = new Unites("longueurs", "Millimetres", 1, true);
            unites.Add(mlm);
            Unites cm = new Unites("longueurs", "Centimetres", 0.1);
            unites.Add(cm);
            Unites pouce = new Unites("longueurs", "Pouces", 0.0394);
            unites.Add(pouce);
            Unites m = new Unites("longueurs", "Metres", 0.001);
            unites.Add(m);
            Unites hm = new Unites("longueurs", "Hectometres", 0.00001);
            unites.Add(hm);
            Unites km = new Unites("longueurs", "Kilometres", 0.000001);
            unites.Add(km);

            // Les Frequences
            Unites hertz = new Unites("frequences", "Hertz", 1, true);
            unites.Add(hertz);
            Unites kHertz = new Unites("frequences", "Kilohertz", Math.Pow(10,-3));
            unites.Add(kHertz);
            Unites mHertz = new Unites("frequences", "Megahertz", Math.Pow(10,-6));
            unites.Add(mHertz);
            Unites gHertz = new Unites("frequences", "Gigahertz", Math.Pow(10,-9));
            unites.Add(gHertz);
            Unites tHertz = new Unites("frequences", "Terahertz", Math.Pow(10,-12));
            unites.Add(tHertz);

            // Les Temperatures
            Unites degr = new Unites("temperatures", "Degre Celsius", 1, true);
            unites.Add(degr);
            Unites fahr = new Unites("temperatures", "Fahrenheit", 33.8);
            unites.Add(fahr);
            Unites kelvin = new Unites("temperatures", "Kelvin", 274.15);
            unites.Add(kelvin);
            Unites rankine = new Unites("temperatures", "Rankine", 493.47);
            unites.Add(rankine);

            // Les unites de stockages
            Unites bit = new Unites("stockages", "Bits", 1, true);
            unites.Add(bit);
            Unites octets = new Unites("stockages", "Octets", 0.125);
            unites.Add(octets);
            Unites kBit = new Unites("stockages", "Kilobits", 0.001);
            unites.Add(kBit);
            Unites koctets = new Unites("stockages", "Kilooctets", 0.000976);
            unites.Add(koctets);
            Unites kibib = new Unites("stockages", "Kibibits", 0.001);
            unites.Add(kibib);

            this.valChoisie = valChoisie;
            if (valChoisie == "Angle"){
                this.remplirListStores("angles");
            }else{
                if (valChoisie == "Longueur"){
                    this.remplirListStores("longueurs");
                    }else{
                    if(valChoisie == "Vitesse"){
                        this.remplirListStores("vitesses");
                    }else{
                        if(valChoisie == "Surface"){
                            this.remplirListStores("surfaces");
                        }else{
                            if(valChoisie == "Volume"){
                                this.remplirListStores("volumes");
                            }else{
                                if(valChoisie == "Masse"){
                                    this.remplirListStores("masses");
                                }else{
                                    if(valChoisie == "Temps"){
                                        this.remplirListStores("temps");
                                    }else{
                                        if(valChoisie == "Frequence"){
                                            this.remplirListStores("frequences");
                                        }else{
                                            if(valChoisie == "Temperature"){
                                                this.remplirListStores("temperatures");
                                            }else{
                                                if(valChoisie == "Stockage Numerique"){
                                                    this.remplirListStores("stockages");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
         }
        
        private Convertisseur(Builder builder) : base(builder.GetRawOwnedObject("Window"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            valeur.Changed += ValueChanged;
            from.Changed += InitialChanged;
            to.Changed += FinalChanged;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            // Application.Quit();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            valeuri.Text = valeur.Text;
            double v = 0;
            if(double.TryParse(valeur.Text, out v))
            v1 = double.Parse(valeur.Text);

            convertirUinte(initUnit,finalUnit);
            
        }

        private void InitialChanged(object sender, EventArgs args)
        {
            ComboBox comboBox = (ComboBox)sender;
            TreeIter iter;
            if (comboBox.GetActiveIter(out iter))
            {
                init = (string)comboBox.Model.GetValue(iter, 0);
                foreach (var unit in unites)
                {
                    if(unit.Name == init){
                        this.initUnit = unit;
                    }
                }
            }
            // convertirUinte(initUnit,finalUnit);
        }

         private void FinalChanged(object sender, EventArgs args)
        {
            ComboBox comboBox = (ComboBox)sender;
            TreeIter iter;
            if (comboBox.GetActiveIter(out iter))
            {
                final = (string)comboBox.Model.GetValue(iter, 0);
                foreach (var unit in unites)
                {
                    if(unit.Name == final){
                        this.finalUnit = unit;
                    }
                }
            }
            convertirUinte(initUnit,finalUnit);
        }

        public void convertirUinte(Unites initUnit, Unites finalUnit){
            if(initUnit.BaseUnit){
                v2 = v1*finalUnit.Value;
            }else{
                double init = v1/initUnit.Value;
                v2 = init * finalUnit.Value;
            }

            valeuri.Text = v1 + " " + initUnit.Name;
            
            if (v2.ToString("N4")[4] == '0')
            {
            valeurf.Text = v2 + " " + finalUnit.Name;
            }else{
                valeurf.Text = v2.ToString("N4") + " " + finalUnit.Name;
            }
        }
        public void remplirListStores(string unite){
            foreach (Unites unit in unites)
            {
                if(unit.Type == unite){
                    liststore1.AppendValues(unit.Name);
                    liststore2.AppendValues(unit.Name);
                }    
            }
        }
    }

}
