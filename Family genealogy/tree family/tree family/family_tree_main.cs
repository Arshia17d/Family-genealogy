using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree_family
{
    class family_tree_main
    {
        public static Hashtable main_hashtable = new Hashtable();

        public static void data_add()
        {
            main_Node a = new main_Node();
            a.Name = "mohamad";
            a.SSN = 320;
            a.Sex = "male";
            main_Node f = new main_Node();
            f.Name = "fateme";
            f.SSN = 321;
            f.Sex = "female";
            family_tree_main.main_hashtable.Add(a.SSN, a);
            family_tree_main.main_hashtable.Add(f.SSN, f);
            marid_person("320", "321", "1402-07-04");
            Born_chaild("320", "321", "ali", "100", "1402-07-04", "male");
            Born_chaild("320", "321", "zahra", "101", "1402-07-04", "female");
            Born_chaild("320", "321", "maryam", "102", "1402-07-04", "female");
            Born_chaild("320", "321", "reza", "103", "1402-07-04", "male");
            main_Node r = new main_Node();
            r.Name = "roya";
            r.SSN = 104;
            r.Sex = "female";
            family_tree_main.main_hashtable.Add(r.SSN, r);
            marid_person("103", "104", "1402-07-04");
            Born_chaild("103", "104", "mobina", "105", "1402-07-04", "female");
            Born_chaild("103", "104", "mostaf", "106", "1402-07-04", "male");
            Born_chaild("103", "104", "zaynab", "107", "1402-07-04", "female");
            Born_chaild("103", "104", "rasol", "108", "1402-07-04", "male");
            main_Node m = new main_Node();
            m.Name = "javad";
            m.SSN = 109;
            m.Sex = "male";
            family_tree_main.main_hashtable.Add(m.SSN, m);
            marid_person("109", "101", "1402-07-04");
            Born_chaild("109", "101", "hosin", "110", "1402-07-04", "male");
            Born_chaild("109", "101", "freshte", "111", "1402-07-04", "female");
            Born_chaild("109", "101", "nastran", "112", "1402-07-04", "female");
            Born_chaild("109", "101", "shahin", "113", "1402-07-04", "male");
            main_Node h = new main_Node();
            h.Name = "moein";
            h.SSN = 114;
            h.Sex = "male";
            family_tree_main.main_hashtable.Add(h.SSN, h);
            marid_person("114", "102", "1402-07-04");
            Born_chaild("114", "102", "esi", "115", "1402-07-04", "male");
            Born_chaild("114", "102", "hashem", "116", "1402-07-04", "male");
            Born_chaild("114", "102", "romina", "117", "1402-07-04", "female");
            Born_chaild("114", "102", "asena", "118", "1402-07-04", "female");
        }

        public static string ADD_person(string name, string SSN, string barthday, string sex)
        {
            if (name == "" || SSN == "" || barthday == "" || sex == "")
            {
                return "null";
            }

            int SSn = Convert.ToInt32(SSN);
            DateTime borntime = default(DateTime);


            bool isValidDate = false;
            while (!isValidDate)
            {
                try
                {
                    borntime = Convert.ToDateTime(barthday);

                    isValidDate = true;
                }
                catch (FormatException)
                {
                    return
                        "Error input datetime!. \n note: 'The month entered must be less than or equal to 12'/n note: 'The day entered must be less than or equal to 31'/n Invalid format!Please enter the date in the format (yyyy - mm - dd):";
                }
            }


            if (sex == "male" || sex == "female")
            {
                string temp = sex;
                main_Node New_person = new main_Node();
                New_person.Name = name;
                New_person.SSN = SSn;
                New_person.Birth = borntime;
                New_person.Sex = temp;

                string t = main_hashtable.Add(New_person.SSN, New_person);
                return t;
            }
            else
            {
                return "error! please enter the right format.sex..\n";
            }
        }

        public static string marid_person(string hus, string wife, string datemarid)
        {
            if (hus == "" || wife == "" || datemarid == "")
            {
                return "null";
            }

            int SSN_hus = Convert.ToInt32(hus);
            int SSN_wife = Convert.ToInt32(wife);

            DateTime date_of_marid = default(DateTime);


            bool isValidDate = false;
            while (!isValidDate)
            {
                try
                {
                    date_of_marid = Convert.ToDateTime(datemarid);

                    isValidDate = true;
                }
                catch (FormatException)
                {
                    return
                        "Error input datetime!. \n note: 'The month entered must be less than or equal to 12'/n note: 'The day entered must be less than or equal to 31'/n Invalid format!Please enter the date in the format (yyyy - mm - dd):";
                }
            }

            main_Node husbent = (main_Node)main_hashtable.Get(SSN_hus);
            main_Node _wife = (main_Node)main_hashtable.Get(SSN_wife);
            if (husbent == null || _wife == null)
            {
                return "hus or wife not exist...";
            }

            if (husbent.Sex == _wife.Sex)
            {
                return "Error: sex husbent==sex wife";
            }

            if (husbent.latest_mar != null && husbent.latest_mar == _wife.latest_mar)
            {
                return "These two people are already married.";
            }

            main_Node Lasth = husbent.latest_mar;
            main_Node lastw = _wife.latest_mar;

            main_Node marid = new main_Node();
            marid.date_of_mar = date_of_marid;

            marid.Prev_mar_hus = Lasth;
            marid.Prev_mar_wife = lastw;
            husbent.latest_mar = marid;
            _wife.latest_mar = marid;
            marid.type = "marid";
            marid.Hus = husbent;
            marid.Wife = _wife;
            string SSN_marriage = SSN_hus.ToString() + SSN_wife.ToString();

            // تبدیل رشته چسبیده شده به عدد صحیح
            int marriageKey = Convert.ToInt32(SSN_marriage);
            string t = main_hashtable.Add(marriageKey, marid);
            return t;
        }

        public static string Born_chaild(string S_DAD, string S_Mom, string name_chaild, string S_Chaild,
            string birthday_chaild, string Sex_chaild)
        {
            if (S_DAD == "" || S_Mom == "" || name_chaild == "" || S_Chaild == "" || birthday_chaild == "" ||
                Sex_chaild == "")
            {
                return "null";
            }

            int S_dad = Convert.ToInt32(S_DAD);
            int S_mom = Convert.ToInt32(S_Mom);
            int S_chaild = Convert.ToInt32(S_Chaild);
            DateTime Brith_chaild = default(DateTime);
            bool isValidDate = false;
            while (!isValidDate)
            {
                try
                {
                    Brith_chaild = Convert.ToDateTime(birthday_chaild);

                    isValidDate = true;
                }
                catch (FormatException)
                {
                    return
                        "Error input datetime!. \n note: 'The month entered must be less than or equal to 12'/n note: 'The day entered must be less than or equal to 31'/n Invalid format!Please enter the date in the format (yyyy - mm - dd):";
                }
            }

            if (!main_hashtable.allkey(S_mom) || !main_hashtable.allkey(S_dad))
            {
                return "Error: Mom's or Dad  SSN not found in the hashtable, please tryagain...";
            }

            if (Sex_chaild == "male" || Sex_chaild == "female")
            {
                main_Node Dad = (main_Node)main_hashtable.Get(S_dad);
                main_Node Mom = (main_Node)main_hashtable.Get(S_mom);
                if (Dad.latest_mar != null && Mom.latest_mar != null && Dad.latest_mar == Mom.latest_mar)
                {
                    main_Node child = new main_Node();
                    child.Name = name_chaild;
                    child.SSN = S_chaild;
                    child.Birth = Brith_chaild;
                    child.Sex = Sex_chaild;
                    child.Dad = Dad;
                    child.Mom = Mom;
                    Dad.latest_child = child;
                    Mom.latest_child = child;
                    string t = main_hashtable.Add(child.SSN, child);
                    return t;
                }
                else
                {
                    return " not marid";
                }
            }
            else
            {
                return "gender not found.....";
            }
        }

        public static string change_SSN(string s_person, string new_SSn)
        {
            if (s_person == "" || new_SSn == "")
            {
                return "null";
            }

            int SSN_Persone = Convert.ToInt32(s_person);
            main_Node Person_SSN_change = (main_Node)main_hashtable.Get(SSN_Persone);
            if (Person_SSN_change == null)
            {
                return "SSN not fond....";
            }

            int SSN_New = Convert.ToInt32(new_SSn);
            if (!main_hashtable.allkey(SSN_New))
            {
                Person_SSN_change.SSN = SSN_New;
                return "Change successfully !!..";
            }
            else
            {
                return "Error : this new SSN already have exit....";
            }
        }

        public static string change_name(string s_person, string new_name)
        {
            if (s_person == "" || new_name == "")
            {
                return "null";
            }

            int SSN_Person = Convert.ToInt32(s_person);
            main_Node person_name_change = (main_Node)main_hashtable.Get(SSN_Person);
            if (person_name_change == null)
            {
                return "SSN not fond....";
            }

            person_name_change.Name = new_name;
            return "Change successfully !!..";
        }

        public static string change_deadtime(string S_person, string deate_new)
        {
            if (S_person == "" || deate_new == "")
            {
                return "null";
            }


            int SSN_Person = Convert.ToInt32(S_person);
            main_Node person_deadtime_change = (main_Node)main_hashtable.Get(SSN_Person);
            if (person_deadtime_change == null)
            {
                return "person not found...";
            }

            DateTime new_deadtime = default(DateTime);
            bool isValidDate = false;
            while (!isValidDate)
            {
                try
                {
                    new_deadtime = DateTime.Parse(deate_new);

                    isValidDate = true;
                }
                catch (FormatException)
                {
                    return
                        "Error input datetime!. \n note: 'The month entered must be less than or equal to 12'/n note: 'The day entered must be less than or equal to 31'/n Invalid format!Please enter the date in the format (yyyy - mm - dd):";
                }
            }

            person_deadtime_change.Death = new_deadtime;
            return "Change successfully !!..";
        } 
        

        public static string change_borntime(string S_person, string deate_born)
        {
            if (S_person == "" || deate_born == "")
            {
                return "null";
            }

            int SSN_Person = Convert.ToInt32(S_person);
            main_Node person_borntime_change = (main_Node)main_hashtable.Get(SSN_Person);
            if (person_borntime_change == null)
            {
                return "person not found...";
            }

            DateTime new_borntime = default(DateTime);
            bool isValidDate = false;
            while (!isValidDate)
            {
                try
                {
                    new_borntime = DateTime.Parse(deate_born);

                    isValidDate = true;
                }
                catch (FormatException)
                {
                    return
                        "Error input datetime!. \n note: 'The month entered must be less than or equal to 12'/n note: 'The day entered must be less than or equal to 31'/n Invalid format!Please enter the date in the format (yyyy - mm - dd):";
                }
            }

            person_borntime_change.Death = new_borntime;
            return "Change successfully !!..";
        }

        //relationship function...
        public static string R_husband_name(string SSn)
        {
            if (SSn == "")
            {
                return "null";
            }

            int temp = Convert.ToInt32(SSn);
            main_Node T = (main_Node)main_hashtable.Get(temp);
            if (T == null)
            {
                return "SSN not fond";
            }

            if (T.Sex == "male")
            {
                return "The gender not match";
            }

            if (T.latest_mar == default(main_Node))
            {
                return "Not married.";
            }

            return "this husbant:" + T.latest_mar.Hus.Name;
        }

        public static string R_wife_name(string SSn)
        {
            if (SSn == "")
            {
                return "null";
            }

            int SSN_person = Convert.ToInt32(SSn);
            main_Node person = (main_Node)main_hashtable.Get(SSN_person);
            if (person == null)
            {
                return "SSN not found...";
            }

            if (person.Sex == "female")
            {
                return "The gender not match.";
            }

            if (person.latest_mar == default(main_Node))
            {
                return "Not married.";
            }

            return "wife is:" + person.latest_mar.Wife.Name;
        }

        public static string R_Dad_name(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int D_person = Convert.ToInt32(SSN);
            main_Node D = (main_Node)main_hashtable.Get(D_person);
            if (D == null)
            {
                return "SSN not found";
            }

            if (D.Dad == null)
            {
                return "not found Dad person";
            }

            if (D.Dad.Death != default(DateTime))
            {
                return "dad is death:" + D.Dad.Name;
            }

            return "dad is :" + D.Dad.Name;
        }

        public static string R_mom_name(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int M_person = Convert.ToInt32(SSN);
            main_Node M = (main_Node)main_hashtable.Get(M_person);
            if (M == null)
            {
                return " SSN not found..";
            }

            if (M.Mom == null)
            {
                return "not found Mom person";
            }

            if (M.Mom.Death != default(DateTime))
            {
                return "Mom is death:" + M.Mom.Name;
            }

            return "mom  is :" + M.Mom.Name;
        }

        public static string R_just_Broter(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int SSN_Brother = Convert.ToInt32(SSN);
            main_Node S_B = main_hashtable.Get(SSN_Brother);
            if (S_B == null)
            {
                return "not found SSN";
            }

            if (S_B.Dad == default(main_Node) || S_B.Mom == default(main_Node))
            {
                return "dad or mom not found";
            }

            main_Node Mom_person = S_B.Mom;
            main_Node Dad_person = S_B.Dad;
            int i = 1;
            var allNodes = main_hashtable.GetAllNodes();
            string brother = default(string);
            foreach (main_Node person in allNodes)
            {
                if (person.type == null && person.Sex == "male" && person != S_B)
                {
                    if (person.Dad == Dad_person || person.Mom == Mom_person)
                    {
                        brother = brother + i + ".Brother :" + person.Name + "\n";
                        i++;
                    }
                }
            }

            if (brother == default(string))
            {
                return " not broter";
            }

            return brother;
        }

        //تابع با ورودی برای استفاده در تابع عمو و دایی
        public static string A_just_Broter(main_Node temp)
        {
            if (temp.Sex == "male")
            {
                if (temp.Dad == default(main_Node) || temp.Mom == default(main_Node))
                {
                    return "Error :not found grand father or grand mother..! ";
                }

                main_Node Mom_person = temp.Mom;
                main_Node Dad_person = temp.Dad;
                int i = 1;
                var allNodes = main_hashtable.GetAllNodes();
                string amoo = default(string);
                foreach (main_Node person in allNodes)
                {
                    if (person.type == null && person.Sex == "male" && person != temp)
                    {
                        if (person.Dad == Dad_person || person.Mom == Mom_person)
                        {
                            amoo = amoo + i + "uncles:" + person.Name + "\n";
                            i++;
                        }
                    }
                }

                if (amoo == default(string))
                {
                    return "person dont ammo  ....!";
                }

                return "person amoo is :\n" + amoo;
            }

            if (temp.Sex == "female")
            {
                if (temp.Dad == default(main_Node) || temp.Mom == default(main_Node))
                {
                    return "Error :not fund grand father or grand mother..! ";
                }

                main_Node Mom_person = temp.Mom;
                main_Node Dad_person = temp.Dad;
                int i = 1;
                var allNodes = main_hashtable.GetAllNodes();
                string daei = default(string);
                foreach (main_Node person in allNodes)
                {
                    if (person.type == null && person.Sex == "male" && person != temp)
                    {
                        if (person.Dad == Dad_person || person.Mom == Mom_person)
                        {
                            daei = daei + i + "uncles:" + person.Name + "\n";
                            i++;
                        }
                    }
                }

                if (daei == default(string))
                {
                    return "person dont daei....!";
                }

                return "person daei is :\n" + daei;
            }

            return "Error : gender father or mothet not fond ";
        }

        public static string R_just_Sister(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int SSN_sister = Convert.ToInt32(SSN);
            main_Node S_B = main_hashtable.Get(SSN_sister);
            if (S_B == null)
            {
                return "not found SSN";
            }

            if (S_B.Dad == default(main_Node) || S_B.Mom == default(main_Node))
            {
                return "dad or mom not fund";
            }

            main_Node Mom_person = S_B.Mom;
            main_Node Dad_person = S_B.Dad;
            int i = 1;
            var allNodes = main_hashtable.GetAllNodes();
            string sister = default(string);
            foreach (main_Node person in allNodes)
            {
                if (person.type == null && person.Sex == "female" && person != S_B)
                {
                    if (person.Dad == Dad_person || person.Mom == Mom_person)
                    {
                        sister = sister + i + ".Sister :" + person.Name + "\n";
                        i++;
                    }
                }
            }

            if (sister == default(string))
            {
                return " not sister";
            }

            return sister;
        }

        //تابع با ورودی برای استفاده در تابع خاله و عمه
        public static string A_just_Sister(main_Node Mother)
        {
            if (Mother.Sex == "female")
            {
                if (Mother.Mom == default(main_Node) || Mother.Dad == default(main_Node))
                {
                    return "Error :not fund grand father or grand mother..! ";
                }

                main_Node Mom_person = Mother.Mom;
                main_Node Dad_person = Mother.Dad;
                int i = 1;
                var allNodes = main_hashtable.GetAllNodes();
                string khale = default(string);
                foreach (main_Node person in allNodes)
                {
                    if (person.type == null && person.Sex == "female" && person != Mother)
                    {
                        if (person.Dad == Dad_person || person.Mom == Mom_person)
                        {
                            khale = khale + i + "Aunts:" + person.Name + "\n";
                            i++;
                        }
                    }
                }

                if (khale == default(string))
                {
                    return "person dont have khale";
                }

                return "khale person is :\n" + khale;
            }


            if (Mother.Sex == "male")
            {
                if (Mother.Mom == default(main_Node) || Mother.Dad == default(main_Node))
                {
                    return "Error :not fund grand father or grand mother..! ";
                }

                main_Node Mom_person = Mother.Mom;
                main_Node Dad_person = Mother.Dad;
                int i = 1;
                var allNodes = main_hashtable.GetAllNodes();
                string Amee = default(string);
                foreach (main_Node person in allNodes)
                {
                    if (person.type == null && person.Sex == "female" && person != Mother)
                    {
                        if (person.Dad == Dad_person || person.Mom == Mom_person)
                        {
                            Amee = Amee + i + "Aunts:" + person.Name + "\n";
                            i++;
                        }
                    }
                }

                if (Amee == default(string))
                {
                    return "person dont have Amee";
                }

                return "Amee person is :\n" + Amee;
            }

            return "Error : gender father or mothet not fond ";
        }

        public static string R_sister_Brother(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int SSN_Brother = Convert.ToInt32(SSN);
            main_Node S_B = main_hashtable.Get(SSN_Brother);
            if (S_B == null)
            {
                return "SSN not fund";
            }

            if (S_B.Dad == default(main_Node) || S_B.Mom == default(main_Node))
            {
                return "dad or mom dont fund";
            }

            main_Node Mom_person = S_B.Mom;
            main_Node Dad_person = S_B.Dad;
            int i = 1;
            var allNodes = main_hashtable.GetAllNodes();
            string sister_brother = default(string);
            foreach (main_Node person in allNodes)
            {
                if (person.type == null && person != S_B)
                {
                    if (person.Dad == Dad_person || person.Mom == Mom_person)
                    {
                        if (person.Sex == "female")
                        {
                            sister_brother = sister_brother + i + ".Sister :" + person.Name + "\n";
                            i++;
                        }

                        if (person.Sex == "male")
                        {
                            sister_brother = sister_brother + i + ".Brother :" + person.Name + "\n";
                            i++;
                        }
                    }
                }
            }

            if (sister_brother == "")
            {
                return "no brother and sister...!";
            }

            return sister_brother;
        }

        public static string grand_father(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }


            int SSN_person = Convert.ToInt32(SSN);
            main_Node person = main_hashtable.Get(SSN_person);
            if (person == null)
            {
                return "Error:person not find...\n";
            }

            if (person.Dad.Dad == default(main_Node) && person.Mom.Dad == default(main_Node))
            {
                return "garnd_father_dad is :" + "null" + "\n" + "grand_mom_dad is :" + "null";
            }

            if (person.Dad.Dad == default(main_Node))
            {
                return "garnd_father_dad is :" + "null" + "\n" + "grand_mom_dad is :" + person.Mom.Dad.Name;
            }

            if (person.Mom.Dad == default(main_Node))
            {
                return "garnd_father_dad is: " + person.Dad.Dad.Name + "\n" + "grand_mom_dad  is :" + "null";
            }

            return "garnd_father_dad is :" + person.Dad.Dad.Name + "\n" + "grand_mom_dad is :" + person.Mom.Dad.Name;
        }

        public static string grand_mom(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }


            int SSN_person = Convert.ToInt32(SSN);
            main_Node person = main_hashtable.Get(SSN_person);
            if (person == null)
            {
                return "Error:person not find...\n";
            }

            if (person.Mom.Mom == default(main_Node))
            {
                return "grabd_mom_mother is :" + "null" + "\n" + "grand_mom_father is :" + person.Dad.Mom.Name;
            }

            if (person.Dad.Mom == default(main_Node))
            {
                return "grabd_mom_mother is :" + person.Mom.Mom.Name + "\n" + "grand_mom_father is :" + "null";
            }


            return "grabd_mom_mother is :" + person.Mom.Mom.Name + "\n" + "grand_mom_father is :" + person.Dad.Mom.Name;
        }

        public static string Children(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int PersonSSN = Convert.ToInt32(SSN);
            main_Node _PersonSSN = main_hashtable.Get(PersonSSN);
            if (_PersonSSN == null)
            {
                return "Error:SSN not found in the hashtable.";
            }


            int childCount = 0;
            string child = default(string);
            foreach (main_Node person in main_hashtable.GetAllNodes())
            {
                if (person.Dad == _PersonSSN || person.Mom == _PersonSSN)
                {
                    child = child + ++childCount + ". " + person.Name + "\n";
                }
            }

            if (childCount == 0)
            {
                return "No children found for this person!.";
            }

            return "Children of " + _PersonSSN.Name + ":\n" + child;
        }

        public static string grandchild(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int PersonSSN = Convert.ToInt32(SSN);
            main_Node _PersonSSN = main_hashtable.Get(PersonSSN);
            if (_PersonSSN == null)
            {
                return "Error:SSN not found in the hashtable.";
            }

            int GrandchildCount = 0;
            string grand_child = default(string);

            foreach (main_Node person in main_hashtable.GetAllNodes())
            {
                if (person.type == "marid")
                {
                    continue;
                }

                if (person.Dad == default(main_Node) || person.Mom == default(main_Node))
                {
                    continue;
                }

                if (person.Dad.Dad != default(main_Node) || person.Dad.Mom != default(main_Node) ||
                    person.Mom.Dad != default(main_Node) || person.Mom.Mom != default(main_Node))
                {
                    if (person.Dad.Dad == _PersonSSN || person.Dad.Mom == _PersonSSN || person.Mom.Dad == _PersonSSN ||
                        person.Mom.Mom == _PersonSSN)
                    {
                        grand_child = grand_child + ++GrandchildCount + ". " + person.Name + "\n";
                    }
                }
            }

            if (grand_child == "")
            {
                return "No Grandchildren found for this person!.";
            }

            return "Grand Children of " + _PersonSSN.Name + ":\n" + grand_child;
        }

        public static string ammu(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int personSSN = Convert.ToInt32(SSN);
            main_Node person = main_hashtable.Get(personSSN);
            if (person == null)
            {
                return "Error:SSN not found in the hashtable.";
            }

            main_Node father = person.Dad;
            if (father == null)
            {
                return "Father's information is not available.";
            }

            string AMOO = A_just_Broter(father);
            return AMOO;
        }

        public static string Daei(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int personSSN = Convert.ToInt32(SSN);
            main_Node person = main_hashtable.Get(personSSN);
            if (person == null)
            {
                return "Error:SSN not found in the hashtable.";
            }

            main_Node Mother = person.Mom;
            if (Mother == null)
            {
                return "Mother's information is not available.";
            }

            string DAei = A_just_Broter(Mother);
            return DAei;
        }

        public static string khalle(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int personSSN = Convert.ToInt32(SSN);
            main_Node person = main_hashtable.Get(personSSN);
            if (person == null)
            {
                return "Error:SSN not found in the hashtable.";
            }

            main_Node Mother = person.Mom;
            if (Mother == default(main_Node))
            {
                return "Mother's information is not available.";
            }

            string khale = A_just_Sister(Mother);
            return khale;
        }

        public static string amme(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int personSSN = Convert.ToInt32(SSN);
            main_Node person = main_hashtable.Get(personSSN);
            if (person == null)
            {
                return "Error:SSN not found in the hashtable.";
            }

            main_Node Father = person.Dad;
            if (Father == null)
            {
                return "fathers's information is not available.";
            }

            string amee = A_just_Sister(Father);
            return amee;
        }

        ////////////////////////////////////////////// relation finish::::::://////////////////
        public static string Divorce(string SSN_hus, string SSN_wife)
        {
            if (SSN_hus == "" || SSN_wife == "")
            {
                return "null";
            }

            int husband = Convert.ToInt32(SSN_hus);
            int wife = Convert.ToInt32(SSN_wife);
            if (!main_hashtable.allkey(husband) || !main_hashtable.allkey(wife))
            {
                return "Error:one or two of SSN not found in the hashtable.";
            }

            main_Node _husband = main_hashtable.Get(husband);
            main_Node _wife = main_hashtable.Get(wife);
            if (
                _husband.latest_mar != _wife.latest_mar
                || _husband.latest_mar == null
                || _wife.latest_mar == null
            )
            {
                return "These two people are not married to each other.";
            }

            _husband.latest_mar = null;
            _wife.latest_mar = null;
            return "Divorce process completed successfully.";
        }

        public static string Death(string SSN, string Date)
        {
            if (SSN == "")
            {
                return "null";
            }

            int SSN_Person = Convert.ToInt32(SSN);
            if (!main_hashtable.allkey(SSN_Person))
            {
                return "Error:one or two of SSN not found in the hashtable.";
            }

            DateTime dateperson = default(DateTime);
            try
            {
                dateperson = DateTime.Parse(Date);
            }
            catch (FormatException)
            {
                return
                    "Error input datetime!. \n note: 'The month entered must be less than or equal to 12'/n note: 'The day entered must be less than or equal to 31'/n Invalid format!Please enter the date in the format (yyyy - mm - dd):";
            }

            main_Node _Person = main_hashtable.Get(SSN_Person);
            _Person.Death = dateperson;
            return "successfully...";
        }


        // دختر خاله!!!!
        public static string R_dokhtar_khale(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int SSN_person = Convert.ToInt32(SSN);
            main_Node person = main_hashtable.Get(SSN_person);
            if (person == null)
            {
                return "SSN not found";
            }

            if (person.Mom == default(main_Node))
            {
                return "mom person not fund";
            }

            string t = return_just_Sister(person.Mom);

            return t;
        }

        public static string return_just_Sister(main_Node Mother)
        {
            string dokhtat_khale = default(string);
            if (Mother.Sex == "female")
            {
                if (Mother.Mom == default(main_Node) || Mother.Dad == default(main_Node))
                {
                    return "Error :not fund grand father or grand mother..! ";
                }

                main_Node Mom_person = Mother.Mom;
                main_Node Dad_person = Mother.Dad;
                int i = 1;
                var allNodes = main_hashtable.GetAllNodes();

                foreach (main_Node person in allNodes)
                {
                    if (person.type == null && person.Sex == "female" && person != Mother)
                    {
                        if (person.Dad == Dad_person || person.Mom == Mom_person)
                        {
                            dokhtat_khale = dokhtat_khale + Children_female(person) + "\n";
                        }
                    }
                }

                if (dokhtat_khale == default(string))
                {
                    return "person dont have khale";
                }
            }


            return "dokhtar khale person is :\n" + dokhtat_khale;
        }

        public static string Children_female(main_Node temp)
        {
            if (temp == null)
            {
                return "Error:SSN not found in the hashtable.";
            }


            int childCount = 0;
            string child = default(string);
            foreach (main_Node person in main_hashtable.GetAllNodes())
            {
                if (person.Dad == temp || person.Mom == temp)
                {
                    if (person.Sex == "female")
                    {
                        child = child + ++childCount + ". " + person.Name + "\n";
                    }
                }
            }

            if (childCount == 0)
            {
                return "No children found for this person!.";
            }

            return "dokhtar  of  khale  " + temp.Name + ":\n" + child;
        }

        //////////////////////////////////////////////////////////////////////////// tamam dokhtar khale


        // pesar khalle

        public static string R_pesar_khale(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int SSN_person = Convert.ToInt32(SSN);
            main_Node person = main_hashtable.Get(SSN_person);
            if (person == null)
            {
                return "SSN not found";
            }

            if (person.Mom == default(main_Node))
            {
                return "mom person not f0und";
            }

            string t = return_just__Sister(person.Mom);
            return t;
        }

        public static string return_just__Sister(main_Node Mother)
        {
            string pesar_khale = default(string);
            if (Mother.Sex == "female")
            {
                if (Mother.Mom == default(main_Node) || Mother.Dad == default(main_Node))
                {
                    return "Error :not fund grand father or grand mother..! ";
                }

                main_Node Mom_person = Mother.Mom;
                main_Node Dad_person = Mother.Dad;
                int i = 1;
                foreach (main_Node person in main_hashtable.GetAllNodes())
                {
                    if (person.type == null && person.Sex == "female" && person != Mother)
                    {
                        if (person.Dad == Dad_person || person.Mom == Mom_person)
                        {
                            pesar_khale = pesar_khale + Children_male(person) + "\n";
                        }
                    }
                }

                if (pesar_khale == default(string))
                {
                    return "person dont have khale";
                }
            }

            return "dokhtar khale person is :\n" + pesar_khale;
        }

        public static string Children_male(main_Node temp)
        {
            if (temp == null)
            {
                return "Error:SSN not found in the hashtable.";
            }

            int childCount = 0;
            string child = default(string);
            foreach (main_Node person in main_hashtable.GetAllNodes())
            {
                if (person.Dad == temp || person.Mom == temp)
                {
                    if (person.Sex == "male")
                    {
                        child = child + ++childCount + ". " + person.Name + "\n";
                    }
                }
            }

            if (childCount == 0)
            {
                return "No children found for this person!.";
            }

            return "pesar  of  khale  " + temp.Name + ":\n" + child;
        }


        //  new fun for pesar_khale//////// 

        //


        public static string Ru_pesar_khale(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int SSN_person = Convert.ToInt32(SSN);
            main_Node person = main_hashtable.Get(SSN_person);
            if (person == null)
            {
                return "SSN not found";
            }

            if (person.Mom == default(main_Node))
            {
                return "mom person not f0und";
            }

            string t = Return_just__Sister(person.Mom);
            return t;
        }

        public static string Return_just__Sister(main_Node Mother)
        {
            string pesar_khale = default(string);
            if (Mother.Sex == "female")
            {
                if (Mother.Mom == default(main_Node) || Mother.Dad == default(main_Node))
                {
                    return "Error :not fund grand father or grand mother..! ";
                }

                main_Node Mom_person = Mother.Mom;
                main_Node Dad_person = Mother.Dad;
                int i = 1;
                var sistersOfMother = main_hashtable
                    .GetAllNodes()
                    .Where(
                        node =>
                            node.Mom == Mother.Mom
                            && node.Dad == Mother.Dad
                            && node != Mother
                            && node.Sex == "female"
                    );
                foreach (main_Node person in sistersOfMother)
                {
                    if (person.type == null && person.Sex == "female" && person != Mother)
                    {
                        if (person.Dad == Dad_person || person.Mom == Mom_person)
                        {
                            pesar_khale = pesar_khale + CIhildren_male(person) + "\n";
                        }
                    }
                }

                if (pesar_khale == default(string))
                {
                    return "person dont have khale";
                }
            }

            return "dokhtar khale person is :\n" + pesar_khale;
        }

        public static string CIhildren_male(main_Node temp)
        {
            if (temp == null)
            {
                return "Error:SSN not found in the hashtable.";
            }

            int childCount = 0;
            string child = default(string);
            foreach (main_Node person in main_hashtable.GetAllNodes())
            {
                if (person.Dad == temp || person.Mom == temp)
                {
                    if (person.Sex == "male")
                    {
                        child = child + ++childCount + ". " + person.Name + "\n";
                    }
                }
            }

            if (childCount == 0)
            {
                return "No children found for this person!.";
            }

            return "pesar  of  khale  " + temp.Name + ":\n" + child;
        }


        //////// newq fun
        // Dokhtar khalle
        public static string RU_dokhtar_khale(string SSN)
        {
            if (SSN == "")
            {
                return "null";
            }

            int SSN_person = Convert.ToInt32(SSN);
            main_Node person = main_hashtable.Get(SSN_person);
            if (person == null)
            {
                return "SSN not found";
            }

            if (person.Mom == default(main_Node))
            {
                return "mom person not found";
            }

            string t = RUeturn_just_Sister(person.Mom);

            return t;
        }

        public static string RUeturn_just_Sister(main_Node Mother)
        {
            string dokhtat_khale = default(string);
            if (Mother.Sex == "female")
            {
                if (Mother.Mom == default(main_Node) || Mother.Dad == default(main_Node))
                {
                    return "Error :not found grand father or grand mother..! ";
                }

                main_Node Mom_person = Mother.Mom;
                main_Node Dad_person = Mother.Dad;
                int i = 1;
                //var allNodes = main_hashtable.GetAllNodes();

                var sistersOfMother = main_hashtable
                    .GetAllNodes()
                    .Where(
                        node =>
                            node.Mom == Mother.Mom
                            && node.Dad == Mother.Dad
                            && node != Mother
                            && node.Sex == "female"
                    );
                foreach (main_Node person in sistersOfMother)
                {
                    if (person.type == null && person.Sex == "female" && person != Mother)
                    {
                        if (person.Dad == Dad_person || person.Mom == Mom_person)
                        {
                            dokhtat_khale = dokhtat_khale + Children_female(person, sistersOfMother) + "\n";
                        }
                    }
                }

                if (dokhtat_khale == default(string))
                {
                    return "person dont have khale";
                }
            }

            return "dokhtar khale person is :\n" + dokhtat_khale;
        }

        public static string Children_female(main_Node temp, IEnumerable<main_Node> sistersOfMother)
        {
            if (temp == null)
            {
                return "Error:SSN not found in the hashtable.";
            }

            int childCount = 0;
            string child = default(string);
            foreach (main_Node person in sistersOfMother)
            {
                if (person.Dad == temp || person.Mom == temp)
                {
                    if (person.Sex == "female")
                    {
                        child = child + ++childCount + ". " + person.Name + "\n";
                    }
                }
            }

            if (child == "")
            {
                return "No children found for this person!.";
            }

            return "dokhtar  of  khale  " + temp.Name + ":\n" + child;
        }
    }
}