using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public struct mcViewStruct {
    private int cid;
    private Control contentLabel;
    private Control checkbox;
    private CheckBox checkboxTF;
    public int CID {
        get {
            return cid;
        }
        set {
            cid = value;
        }
    }
    public Control Content {
        get {
            return contentLabel;
        }
        set {
            contentLabel = value;
        }
    }
    public Control Checkbox {
        get {
            return checkbox;
        }
        set {
            checkbox = value;
        }
    }

    public CheckBox CheckboxTF {
        get {
            return checkboxTF;
        }
        set {
            checkboxTF = value;
        }
    }
}