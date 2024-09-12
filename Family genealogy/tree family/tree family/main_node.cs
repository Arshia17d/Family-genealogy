using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree_family
{
    class main_Node
    {
        public int SSN;
        public string Name;
        public DateTime Birth;
        public DateTime Death;
        public string Sex;
        public main_Node Dad; // اشاره‌گر به پدر
        public main_Node Hus; // اشاره‌گر به شوهر
        public main_Node Mom; // اشاره‌‌گر به مادر
        public main_Node Wife; // اشاره‌گر به همسر زن
        public main_Node prev_child_for_dad; // اشاره‌گر به فرزند قبلی پدر
        public main_Node prev_child_for_Mom; // اشاره گر به فرزند قبلی مادر
        public main_Node Prev_mar_wife; // اشارهگر به گره قبلی ازدواج زن
        public main_Node Prev_mar_hus; // اشاره‌گر به گره قبلی ازدواج شوهر
        public main_Node latest_child; // اشاره‌گر به آخرین فرزند این گره

        public main_Node latest_mar; // اشاره‌گر به آخرین گره ازدواج این فرد

        //  public main_Node right; // اشاره‌گر مربوط به درخت جستجوی دودویی
        // public main_Node left; // اشاره‌گر مربوط به درخت جستجوی دودویی
        public string type; // نوع گره
        public DateTime date_of_mar; // تاریخ ازدواج
        public DateTime date_mar_end; //تاریخ طلاق یا پایان ازدواج

        //سازنده اول
        public main_Node(
            main_Node _dad,
            main_Node _mom,
            main_Node _prev_child_for_dad,
            main_Node _prev_child_for_mom,
            main_Node _latest_child,
            main_Node _latest_mar,
            DateTime _death,
            DateTime _birth,
            string _name,
            int _SSN,
            string _sex
        )

        {
            this.Dad = _dad;
            this.Mom = _mom;
            this.Birth = _birth;
            this.prev_child_for_dad = _prev_child_for_dad;
            this.prev_child_for_Mom = _prev_child_for_mom;
            this.latest_child = _latest_child;
            this.latest_mar = _latest_mar;
            this.Death = _death; // باید زمان مرگ خالی باشد
        }

        public main_Node()
        {
        }

        public main_Node(main_Node hus, main_Node wife, DateTime dat_of_marid, main_Node prev_mar_hus,
            main_Node prev_mar_waif
        )
        {
            this.Hus = hus;
            this.Wife = wife;
            this.date_of_mar = dat_of_marid;
            this.type = "Marid";
            this.Prev_mar_hus = prev_mar_hus;
            this.Prev_mar_wife = prev_mar_waif;
        }
    }

    class Marid
    {
        main_Node hus;
        main_Node wife;
        DateTime dat_of_marid;
        DateTime dat_of_marid_end;
        main_Node prev_mar_hus;
        main_Node prev_mar_waif;
        string type;

        public Marid()
        {
        }
    }
}