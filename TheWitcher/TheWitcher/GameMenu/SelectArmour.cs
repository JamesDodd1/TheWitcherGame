using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Travel.GameMenu.Components;

namespace Travel.GameMenu
{
    /// <summary>  </summary>
    class SelectArmour
    {
        /// <summary> Initialises a new instance of SelectArmour </summary>
        /// <param name="panel"> The panel which Select Armour is added to </param>
        public SelectArmour(Panel panel)
        {
            this.panel = panel;

            SetArmourSelectLayout();
        }


        /// <summary> Shows the Armour Selection on the Menu Panel </summary>
        public void Show()
        {
            try
            {
                this.panel.Controls.Add(this.armourLbl);
                this.panel.Controls.Add(this.noArmourPic);
                this.panel.Controls.Add(this.clothesPic);
                this.panel.Controls.Add(this.lightArmourPic);
                this.panel.Controls.Add(this.heavyArmourPic);
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Object {0} has not been set within {1}", nameof(this.panel), nameof(SelectArmour));
            }
        }


        /// <summary> Removes the Armour Selection from the Menu Panel </summary>
        public void Hide()
        {
            try
            {
                this.panel.Controls.Remove(this.armourLbl);
                this.panel.Controls.Remove(this.noArmourPic);
                this.panel.Controls.Remove(this.clothesPic);
                this.panel.Controls.Remove(this.lightArmourPic);
                this.panel.Controls.Remove(this.heavyArmourPic);
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Object {0} has not been set within {1}", nameof(this.panel), nameof(SelectArmour));
            }
        }


        /// <summary> Sets up the Armour Selection layout </summary>
        private void SetArmourSelectLayout()
        {
            this.armourLbl = new MenuLabel();
            this.noArmourPic = new WeaponPictureBox();
            this.clothesPic = new WeaponPictureBox();
            this.lightArmourPic = new WeaponPictureBox();
            this.heavyArmourPic = new WeaponPictureBox();


            // Weapon label
            this.armourLbl.Name = "armourLbl";
            this.armourLbl.Text = "ARMOUR SELECTED";
            this.armourLbl.Style = TextStyle.Normal;
            this.armourLbl.Location = new Point(25, 215);


            // No armour picturebox
            this.noArmourPic.Image = Image.FromFile(@".\Images\Witcher\witcher.png");
            this.noArmourPic.Location = new Point(25, 245);
            this.noArmourPic.Name = "noArmourPic";
            this.noArmourPic.Click += NoArmourPic_Click;


            // Clothes picturebox
            this.clothesPic.Image = Image.FromFile(@".\Images\Witcher\witcher.png");
            this.clothesPic.Location = new Point(133, 245);
            this.clothesPic.Name = "clothesPic";
            this.clothesPic.Selected = true;
            this.clothesPic.Click += ClothesPic_Click;


            // Light armour picturebox
            this.lightArmourPic.Image = Image.FromFile(@".\Images\Witcher\witcher.png");
            this.lightArmourPic.Location = new Point(242, 245);
            this.lightArmourPic.Name = "lightArmourPic";
            this.lightArmourPic.Click += LightArmourPic_Click;


            // Heavy armour picturebox
            this.heavyArmourPic.Image = Image.FromFile(@".\Images\Witcher\witcher.png");
            this.heavyArmourPic.Location = new Point(350, 245);
            this.heavyArmourPic.Name = "heavyArmourPic";
            this.heavyArmourPic.Click += HeavyArmourPic_Click;
        }


        /// <summary> Selects No Armour when the No Armour picture box is clicked </summary>
        private void NoArmourPic_Click(object sender, EventArgs e)
        {
            Console.WriteLine("No Armour Selected");

            Selection(this.noArmourPic);
        }


        /// <summary> Selects Clothes when the Clothes picture box is clicked </summary>
        private void ClothesPic_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Clothes Selected");

            Selection(this.clothesPic);
        }


        /// <summary> Selects Light Armour when the Light Armour picture box is clicked </summary>
        private void LightArmourPic_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Armour Selected");

            Selection(this.lightArmourPic);
        }


        /// <summary> Selects Heavy Armour when the Heavy Armour picture box is clicked </summary>
        private void HeavyArmourPic_Click(object sender, EventArgs e) 
        {
            Console.WriteLine("Heavy Armour Selected");

            Selection(this.heavyArmourPic);
        }


        /// <summary> Changes the armour selection states </summary>
        /// <param name="armour"> The armour which is selected </param>
        private void Selection(PictureBox armour)
        {
            noArmourPic.Selected = (armour == noArmourPic);
            clothesPic.Selected = (armour == clothesPic);
            lightArmourPic.Selected = (armour == lightArmourPic);
            heavyArmourPic.Selected = (armour == heavyArmourPic);
        }


        private Panel panel;
        private MenuLabel armourLbl;
        private WeaponPictureBox noArmourPic;
        private WeaponPictureBox clothesPic;
        private WeaponPictureBox lightArmourPic;
        private WeaponPictureBox heavyArmourPic;
    }
}
