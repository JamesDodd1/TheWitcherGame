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
    /// <summary> Generates the weapon selection </summary>
    class SelectWeapon
    {
        /// <summary> Initialise a new instance of SelectWeapon </summary>
        /// <param name="panel"> The Panel the Weapon Selection will be added to </param>
        public SelectWeapon(Panel panel)
        {
            this.panel = panel;

            SetWeaponSelectLayout();
        }


        /// <summary> Shows the Weapon Selection on the Menu Panel </summary>
        public void Show()
        {
            try
            {
                this.panel.Controls.Add(this.weaponLbl);
                this.panel.Controls.Add(this.noWeaponPic);
                this.panel.Controls.Add(this.swordPic);
                this.panel.Controls.Add(this.axePic);
                this.panel.Controls.Add(this.spearPic);
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Object {0} has not been set within {1}", nameof(this.panel), nameof(SelectWeapon));
            }
        }


        /// <summary> Removes the Weapon Selection from the Menu Panel </summary>
        public void Hide()
        {
            try
            {
                this.panel.Controls.Remove(this.weaponLbl);
                this.panel.Controls.Remove(this.noWeaponPic);
                this.panel.Controls.Remove(this.swordPic);
                this.panel.Controls.Remove(this.axePic);
                this.panel.Controls.Remove(this.spearPic);
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Object {0} has not been set within {1}", nameof(this.panel), nameof(SelectWeapon));
            }
        }


        /// <summary> Sets up the Weapon Selection control objects </summary>
        private void SetWeaponSelectLayout()
        {
            // Weapon label
            this.weaponLbl = new MenuLabel();
            this.weaponLbl.Name = "weaponLbl";
            this.weaponLbl.Text = "WEAPON SELECTED";
            this.weaponLbl.Style = TextStyle.Normal;
            this.weaponLbl.Location = new Point(25, 85);


            // No weapon picturebox
            this.noWeaponPic = new WeaponPictureBox();
            this.noWeaponPic.Image = Image.FromFile(@".\Images\Witcher\sword_swing1.png");
            this.noWeaponPic.Location = new Point(25, 115);
            this.noWeaponPic.Name = "noWeaponPic";
            this.noWeaponPic.Click += NoWeaponPic_Click;


            // Sword picturebox
            this.swordPic = new WeaponPictureBox();
            this.swordPic.Image = Image.FromFile(@".\Images\Witcher\sword_swing1.png");
            this.swordPic.Location = new Point(133, 115);
            this.swordPic.Name = "swordPic";
            this.swordPic.Selected = true;
            this.swordPic.Click += SwordPic_Click;


            // Axe picturebox
            this.axePic = new WeaponPictureBox();
            this.axePic.Image = Image.FromFile(@".\Images\Witcher\sword_swing1.png");
            this.axePic.Location = new Point(242, 115);
            this.axePic.Name = "axePic";
            this.axePic.Click += AxePic_Click;


            // Spear picturebox
            this.spearPic = new WeaponPictureBox();
            this.spearPic.Image = Image.FromFile(@".\Images\Witcher\sword_swing1.png");
            this.spearPic.Location = new Point(350, 115);
            this.spearPic.Name = "spearPic";
            this.spearPic.Click += SpearPic_Click;
        }


        /// <summary> Selects No Weapon when the No Weapon picture box is clicked </summary>
        private void NoWeaponPic_Click(object sender, EventArgs e)
        {
            Console.WriteLine("No Weapon Selected");

            Selection(this.noWeaponPic);
        }


        /// <summary> Selects the Sword when the Sword picture box is clicked </summary>
        private void SwordPic_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Sword Selected");

            Selection(this.swordPic);

        }


        /// <summary> Selects the Axe when the Axe picture box is clicked </summary>
        private void AxePic_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Axe Selected");

            Selection(this.axePic);

        }


        /// <summary> Selects the Spear when the Spear picture box is clicked </summary>
        private void SpearPic_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Spear Selected");

            Selection(this.spearPic);
        }


        /// <summary> Changes the weapon selection states </summary>
        /// <param name="weapon"> The weapon which is selected </param>
        private void Selection(PictureBox weapon)
        {
            noWeaponPic.Selected = (weapon == noWeaponPic);
            swordPic.Selected = (weapon == swordPic);
            axePic.Selected = (weapon == axePic);
            spearPic.Selected = (weapon == spearPic);
        }


        private Panel panel;
        private MenuLabel weaponLbl;
        private WeaponPictureBox noWeaponPic;
        private WeaponPictureBox swordPic;
        private WeaponPictureBox axePic;
        private WeaponPictureBox spearPic;
    }
}
