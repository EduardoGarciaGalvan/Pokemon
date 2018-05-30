using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

public class clsResize
{
    public clsResize(Form _form_)
    {
        form = _form_; //the calling form
        _formSize = _form_.ClientSize; //Save initial form size
    }

    private System.Drawing.SizeF _formSize
    {
        get;  set;
    }

    private Form form
    {
        get;  set;
    }

    public void _resize()
    {
        double _form_ratio_width = (double)form.ClientSize.Width /  (double)_formSize.Width;
        double _form_ratio_height = (double) form.ClientSize.Height /  (double)_formSize.Height;
        double _smallest = Math.Min(_form_ratio_width, _form_ratio_height);

        var _controls = _get_all_controls(form);

        foreach (Control control in _controls)
        {
            //Font AutoSize
            control.Font = new System.Drawing.Font(form.Font.FontFamily,
             (float)(Convert.ToDouble(control.Font.Size) * _smallest), control.Font.Style);
          
        }
    }

    private static IEnumerable<Control> _get_all_controls(Control c)
    {
        return c.Controls.Cast<Control>().SelectMany(item =>
            _get_all_controls(item)).Concat(c.Controls.Cast<Control>()).Where(control => 
            control.Name != string.Empty);
    }
}
