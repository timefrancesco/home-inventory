
// This file has been generated by the GUI designer. Do not modify.
namespace FrInventory
{
	public partial class AddItemForm
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.VBox vbox3;

		private global::Gtk.Fixed fixed8;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Fixed fixed6;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Label label4;

		private global::Gtk.Entry tbox_item;

		private global::Gtk.Fixed fixed7;

		private global::Gtk.Fixed fixed12;

		private global::Gtk.VBox vbox4;

		private global::Gtk.VBox vbox5;

		private global::Gtk.Fixed fixed10;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Fixed fixed11;

		private global::Gtk.HBox hbox7;

		private global::Gtk.Label label5;

		private global::Gtk.Entry tbox_note;

		private global::Gtk.Fixed fixed13;

		private global::Gtk.Fixed fixed9;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Button buttonOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget FrInventory.AddItemForm
			this.Name = "FrInventory.AddItemForm";
			this.Title = global::Mono.Unix.Catalog.GetString ("Add Item");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child FrInventory.AddItemForm.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.fixed8 = new global::Gtk.Fixed ();
			this.fixed8.Name = "fixed8";
			this.fixed8.HasWindow = false;
			this.vbox3.Add (this.fixed8);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.fixed8]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.fixed6 = new global::Gtk.Fixed ();
			this.fixed6.Name = "fixed6";
			this.fixed6.HasWindow = false;
			this.hbox4.Add (this.fixed6);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.fixed6]));
			w3.Position = 0;
			// Container child hbox4.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Item:");
			this.hbox5.Add (this.label4);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.label4]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.tbox_item = new global::Gtk.Entry ();
			this.tbox_item.CanFocus = true;
			this.tbox_item.Name = "tbox_item";
			this.tbox_item.IsEditable = true;
			this.tbox_item.InvisibleChar = '•';
			this.hbox5.Add (this.tbox_item);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.tbox_item]));
			w5.Position = 1;
			this.hbox4.Add (this.hbox5);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.hbox5]));
			w6.Position = 1;
			// Container child hbox4.Gtk.Box+BoxChild
			this.fixed7 = new global::Gtk.Fixed ();
			this.fixed7.Name = "fixed7";
			this.fixed7.HasWindow = false;
			this.hbox4.Add (this.fixed7);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.fixed7]));
			w7.Position = 2;
			this.vbox3.Add (this.hbox4);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox4]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			this.vbox2.Add (this.vbox3);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vbox3]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.fixed12 = new global::Gtk.Fixed ();
			this.fixed12.Name = "fixed12";
			this.fixed12.HasWindow = false;
			this.vbox2.Add (this.fixed12);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.fixed12]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.fixed10 = new global::Gtk.Fixed ();
			this.fixed10.Name = "fixed10";
			this.fixed10.HasWindow = false;
			this.vbox5.Add (this.fixed10);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.fixed10]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox ();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.fixed11 = new global::Gtk.Fixed ();
			this.fixed11.Name = "fixed11";
			this.fixed11.HasWindow = false;
			this.hbox6.Add (this.fixed11);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.fixed11]));
			w12.Position = 0;
			// Container child hbox6.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox ();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Note:");
			this.hbox7.Add (this.label5);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.label5]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.tbox_note = new global::Gtk.Entry ();
			this.tbox_note.CanFocus = true;
			this.tbox_note.Name = "tbox_note";
			this.tbox_note.IsEditable = true;
			this.tbox_note.InvisibleChar = '•';
			this.hbox7.Add (this.tbox_note);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.tbox_note]));
			w14.Position = 1;
			this.hbox6.Add (this.hbox7);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.hbox7]));
			w15.Position = 1;
			// Container child hbox6.Gtk.Box+BoxChild
			this.fixed13 = new global::Gtk.Fixed ();
			this.fixed13.Name = "fixed13";
			this.fixed13.HasWindow = false;
			this.hbox6.Add (this.fixed13);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.fixed13]));
			w16.Position = 2;
			this.vbox5.Add (this.hbox6);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox6]));
			w17.Position = 1;
			w17.Expand = false;
			w17.Fill = false;
			this.vbox4.Add (this.vbox5);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.vbox5]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.fixed9 = new global::Gtk.Fixed ();
			this.fixed9.Name = "fixed9";
			this.fixed9.HasWindow = false;
			this.vbox4.Add (this.fixed9);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.fixed9]));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
			this.vbox2.Add (this.vbox4);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vbox4]));
			w20.Position = 2;
			w20.Expand = false;
			w20.Fill = false;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(w1[this.vbox2]));
			w21.Position = 0;
			w21.Expand = false;
			w21.Fill = false;
			// Internal child FrInventory.AddItemForm.ActionArea
			global::Gtk.HButtonBox w22 = this.ActionArea;
			w22.Name = "dialog1_ActionArea";
			w22.Spacing = 10;
			w22.BorderWidth = ((uint)(5));
			w22.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w23 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w22[this.buttonCancel]));
			w23.Expand = false;
			w23.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w24 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w22[this.buttonOk]));
			w24.Position = 1;
			w24.Expand = false;
			w24.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 410;
			this.DefaultHeight = 159;
			this.Show ();
			this.buttonOk.Clicked += new global::System.EventHandler (this.OnButtonOkClicked);
		}
	}
}
