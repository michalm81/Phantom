using Magazyn_App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using Rest;
using StgNetRes;

namespace Magazyn_App.ViewModel
{
    public class DeliveryAndMerchVM : ObservableObject
    {
        public Delivery delivery = new Delivery();
        public Supplier supplier = new Supplier();

        public Supplier supplier_for_list = new Supplier();
       // public DeliveryAndMerch delivery_merch = new DeliveryAndMerch();
        public Merch merch = new Merch();

        public DeliveryAndMerch selected_item = new DeliveryAndMerch();

        public ObservableCollection<DeliveryAndMerch> DeliveryAndMerchList = new ObservableCollection<DeliveryAndMerch>();
        public ObservableCollection<DeliveryAndMerch> DeliveryAndMerchListAll = new ObservableCollection<DeliveryAndMerch>();
        public ObservableCollection<DeliveryAndMerch> DeliveryAndMerchListDelivery = new ObservableCollection<DeliveryAndMerch>();
        public ObservableCollection<DeliveryAndMerch> DeliveryAndMerchList2 = new ObservableCollection<DeliveryAndMerch>();

        public ObservableCollection<string> DeliveryNumbers = new ObservableCollection<string>();
        public ObservableCollection<string> merchlist = new ObservableCollection<string>();
        public ObservableCollection<string> Cities = new ObservableCollection<string>();
        public ObservableCollection<string> Streets = new ObservableCollection<string>();
        public ObservableCollection<string> Suppliers = new ObservableCollection<string>();

        public ObservableCollection<Merch> Merch_List = new ObservableCollection<Merch>();
        public ObservableCollection<Delivery> Delivery_List = new ObservableCollection<Delivery>();
        public ObservableCollection<Supplier> Supplier_List = new ObservableCollection<Supplier>();
        
        public ObservableCollection<Merch> Merch_List_All = new ObservableCollection<Merch>();
        public ObservableCollection<Delivery> Delivery_List_All = new ObservableCollection<Delivery>();
        public ObservableCollection<Supplier> Supplier_List_All = new ObservableCollection<Supplier>();
        
        public List<Merch> Merch_List_D = new List<Merch>();
        public List<Delivery> Delivery_List_D = new List<Delivery>();
        public List<Supplier> Supplier_List_D = new List<Supplier>();

        public ObservableCollection<Supplier> Suppliers_List = new ObservableCollection<Supplier>();

        public string filepathdeliveryall = "deliveryall.xml";
        public string filepathdeliverynumbers = "deliverynumbers.xml";

        public string filepathmerchlist = "merchlist.xml";
        
        public string filepathcities = "cities.xml";
        public string filepathstreets = "streets.xml";
        public string filepathsuppliers = "suppliers.xml";

        public string filepathsupplierslist = "supplierslist.xml";

        public string filepathsupplier = "supplier.xml";
        public string filepathmerch = "merch.xml";
        public string filepathdelivery = "delivery.xml";

        public string filepathsupplier_all = "supplier_all.xml";
        public string filepathmerch_all = "merch_all.xml";
        public string filepathdelivery_all = "delivery_all.xml";

        public string filepathsupplier_D = "supplier_D.xml";
        public string filepathmerch_D = "merch_D.xml";
        public string filepathdelivery_D = "delivery_D.xml";

        public string filepathdeliveryandmerch = "deliveryandmerch.xml";
        public string filepathdeliveryandmerch2 = "deliveryandmerch2.xml";

        public DeliveryAndMerchVM()
        { }

        public Supplier Supplier
        {
            get
            {
                return supplier_for_list;
            }
            set
            {
                supplier_for_list = value;
                RaisePropertyChanged("Supplier");
            }
        }

        public ObservableCollection<Supplier> SuppList
        {
            get
            {
                return Suppliers_List;
            }
            set
            {
                Suppliers_List = value;
                RaisePropertyChanged("SuppList");
            }
        }

        public ObservableCollection<DeliveryAndMerch> DAMList
        {
            get
            {
                LoadDeliveryAndMerchAll();
                LoadDeliveryAndMerch();
                LoadDeliveryAndMerch_Delivery();
                return DeliveryAndMerchList;
            }
            set
            {
                DeliveryAndMerchList = value;
                RaisePropertyChanged("DAMList");
            }
        }

        public ObservableCollection<DeliveryAndMerch> DAMListAll
        {
            get
            {
                LoadDeliveryAndMerchAll();
                return DeliveryAndMerchListAll;
            }
            set
            {
                DeliveryAndMerchListAll = value;
                RaisePropertyChanged("DAMListAll");
            }
        }

        public ObservableCollection<DeliveryAndMerch> DAMListDelivery
        {
            get
            {
                
                return DeliveryAndMerchListDelivery;
            }
            set
            {
                DeliveryAndMerchListDelivery = value;
                RaisePropertyChanged("DAMListDelivery");
            }
        }

        public ObservableCollection<string> UnitsList
        {
            get
            {
                return merch.units;
            }
        }

        public ObservableCollection<string> MerchList
        {
            get
            {
                return merchlist;
            }
            set
            {
                merchlist = value;
                RaisePropertyChanged("MerchList");
            }
        }
        
        public ObservableCollection<string> CitiesList
        {
            get
            {
             //   supplier.Cities = LoadList(filepathcities);
                return Cities;
            }
            set
            {
                Cities = value;
                RaisePropertyChanged("CitiesList");
            }
        }

        public ObservableCollection<string> StreetsList
        {
            get
            {
             //   supplier.Streets = LoadList(filepathstreets);
                return Streets;
            }
            set
            {
                Streets = value;
                RaisePropertyChanged("StreetList");
            }
        }

        public ObservableCollection<string> SuppliersList
        {
            get
            {
               // supplier.Suppliers = LoadList(filepathsuppliers);
                return Suppliers;
            }
            set
            {
                Suppliers = value;
                RaisePropertyChanged("SuppliersList");
            }
        }

        public ObservableCollection<string> DeliveryNumbersList
        {
            get
            {
             //   delivery.DeliveryNumbers = LoadList(filepathdeliverynumbers);
                return DeliveryNumbers;
            }
            set
            {
                DeliveryNumbers = value;
                RaisePropertyChanged("DeliveryNumbersList");
            }
        }

        private bool _neworderwindowOpen;
        public bool NewOrderWindowOpen
        {
            get
            {
                return _neworderwindowOpen;
            }
            set
            {
                _neworderwindowOpen = value;
                RaisePropertyChanged("NewOrderWindowOpen");
            }
        }

        public ICommand OpenNewOrderWindowCommand
        {
            get { return new RelayCommand(arg => OpenNewOrderWindow(arg)); }
        }

        private void OpenNewOrderWindow(object open)
        {
            this.NewOrderWindowOpen = Convert.ToBoolean(open);
        }

        private bool _supplywindowOpen;
        public bool SupplyWindowOpen
        {
            get
            {
                return _supplywindowOpen;
            }
            set
            {
                _supplywindowOpen = value;
                RaisePropertyChanged("SupplyWindowOpen");
            }
        }

        public ICommand OpenSupplyWindowCommand
        {
            get { return new RelayCommand(arg => OpenSupplyWindow(arg)); }
        }

        private void OpenSupplyWindow(object open)
        {
            this.SupplyWindowOpen = Convert.ToBoolean(open);
        }

        private bool _ordershistorywindowOpen;
        public bool OrdersHistoryWindowOpen
        {
            get
            {
                return _ordershistorywindowOpen;
            }
            set
            {
                _ordershistorywindowOpen = value;
                RaisePropertyChanged("OrdersHistoryWindowOpen");
            }
        }

        public ICommand OpenOrdersHistoryWindowCommand
        {
            get { return new RelayCommand(arg => OpenOrdersHistoryWindow(arg)); }
        }

        private void OpenOrdersHistoryWindow(object open)
        {
            this.OrdersHistoryWindowOpen = Convert.ToBoolean(open);
        }

        private bool _supplieshistorywindowOpen;
        public bool SuppliesHistoryWindowOpen
        {
            get
            {
                return _supplieshistorywindowOpen;
            }
            set
            {
                _supplieshistorywindowOpen = value;
                RaisePropertyChanged("SuppliesHistoryWindowOpen");
            }
        }

        public ICommand OpenSuppliesHistoryWindowCommand
        {
            get { return new RelayCommand(arg => OpenSuppliesHistoryWindow(arg)); }
        }

        private void OpenSuppliesHistoryWindow(object open)
        {
            this.SuppliesHistoryWindowOpen = Convert.ToBoolean(open);
        }

        private bool _newsupplierwindowOpen;
        public bool NewSupplierWindowOpen
        {
            get
            {
                return _newsupplierwindowOpen;
            }
            set
            {
                _newsupplierwindowOpen = value;
                RaisePropertyChanged("NewSupplierWindowOpen");
            }
        }

        public ICommand OpenNewSupplierWindowCommand
        {
            get { return new RelayCommand(arg => OpenNewSupplierWindow(arg)); }
        }

        private void OpenNewSupplierWindow(object open)
        {
            this.NewSupplierWindowOpen = Convert.ToBoolean(open);
        }
        //
        
        public DeliveryAndMerch Selected_Item
        {
            get
            {
                return selected_item;
            }
            set
            {
                selected_item = value;
                RaisePropertyChanged("Selected_Item");
            }
        }

        public bool Realised
        {
            get
            {
                return delivery.realised;
            }
            set
            {
                delivery.realised = value;
                RaisePropertyChanged("Realised");
            }
        }

        public string SupplierName
        {
            get
            {
                return supplier.supplier_name;
            }
            set
            {
                supplier.supplier_name = value;
                RaisePropertyChanged("SupplierName");
            }
        }

        public string DeliveryNumber
        {
            get
            {
                return delivery.delivery_number;
            }
            set
            {
                delivery.delivery_number = value;
                RaisePropertyChanged("DeliveryNumber");
            }
        }

        public string NIPNumber
        {
            get
            {
                return supplier.nip_number;
            }
            set
            {
                supplier.nip_number = value;
                RaisePropertyChanged("NIPNumber");
            }
        }

        public string City
        {
            get
            {
                return supplier.city_name;
            }
            set
            {
                supplier.city_name = value;
                RaisePropertyChanged("City");
            }
        }

        public string Street
        {
            get
            {
                return supplier.street_name;
            }
            set
            {
                supplier.street_name = value;
                RaisePropertyChanged("Street");
            }
        }

        public string MerchName
        {
            get
            {
                return merch.name;
            }
            set
            {
                merch.name = value;
                RaisePropertyChanged("MerchName");
            }
        }

        public int MerchAmount
        {
            get
            {
                return merch.amount;
            }
            set
            {
                merch.amount = value;
                RaisePropertyChanged("MerchAmount");
            }
        }

        public string Units
        {
            get
            {
                return merch.unit;
            }
            set
            {
                merch.unit = value;
                RaisePropertyChanged("Units");
            }
        }

        public DateTime Date
        {
            get
            {
                return delivery.date.Date;
            }
            set
            {
                delivery.date = value;
                RaisePropertyChanged("Date");
            }
        }

        private ICommand serializeobject_newsuppliercommand;
        public ICommand SerializeObject_NewSupplierCmd
        {
            get
            {
                if (serializeobject_newsuppliercommand == null)
                    serializeobject_newsuppliercommand = new RelayCommand(argument => { SerializeObject_NewSupplier(); });
                return serializeobject_newsuppliercommand;
            }
        }

        private ICommand serializeobject_newordercommand;
        public ICommand SerializeObject_NewOrderCmd
        {
            get
            {
                if (serializeobject_newordercommand == null)
                    serializeobject_newordercommand = new RelayCommand(argument => { SerializeObject_NewOrder(); });
                return serializeobject_newordercommand;
            }
        }

        private ICommand serializeobjectdeliverycommand;
        public ICommand SerializeObjectDeliveryCmd
        {
            get
            {
                if (serializeobjectdeliverycommand == null)
                    serializeobjectdeliverycommand = new RelayCommand(argument => { SerializeObjectDelivery(); });
                return serializeobjectdeliverycommand;
            }
        }

        private ICommand removeordercommand;
        public ICommand RemoveOrderCmd
        {
            get
            {
                if (removeordercommand == null)
                    removeordercommand = new RelayCommand(argument => { RemoveOrder(); });
                return removeordercommand;
            }
        }
        
        private ICommand removeorderallcommand;
        public ICommand RemoveOrderAllCmd
        {
            get
            {
                if (removeorderallcommand == null)
                    removeorderallcommand = new RelayCommand(argument => { RemoveOrderAll(); });
                return removeorderallcommand;
            }
        }

        private ICommand removedeliverycommand;
        public ICommand RemoveDeliveryCmd
        {
            get
            {
                if (removedeliverycommand == null)
                    removedeliverycommand = new RelayCommand(argument => { RemoveDelivery(); });
                return removedeliverycommand;
            }
        }

        private ICommand savestatuscommand;
        public ICommand SaveStatusCmd
        {
            get
            {
                if (savestatuscommand == null)
                    savestatuscommand = new RelayCommand(argument => { SaveStatus(); });
                return savestatuscommand;
            }
        }

        public void LoadDeliveryAndMerch()
        {
            if (File.Exists(filepathsupplierslist))
                Suppliers_List = SerializeClass.DeserializeObject<ObservableCollection<Supplier>>(filepathsupplierslist);
                           
            if (File.Exists(filepathmerch) && File.Exists(filepathdelivery) && File.Exists(filepathsupplier))
            {
                Merch_List = SerializeClass.DeserializeObject<ObservableCollection<Merch>>(filepathmerch);
                Delivery_List = SerializeClass.DeserializeObject<ObservableCollection<Delivery>>(filepathdelivery);
                Supplier_List = SerializeClass.DeserializeObject<ObservableCollection<Supplier>>(filepathsupplier);
                
                
                merchlist = SerializeClass.DeserializeObject<ObservableCollection<string>>(filepathmerchlist);
                Suppliers = SerializeClass.DeserializeObject <ObservableCollection<string>>(filepathsuppliers);
                Cities = SerializeClass.DeserializeObject<ObservableCollection<string>>(filepathcities);
                Streets = SerializeClass.DeserializeObject<ObservableCollection<string>>(filepathstreets);

              //  Suppliers_List = SerializeClass.DeserializeObject<ObservableCollection<Supplier>>(filepathsupplierslist);

                int n = Merch_List.Count();

                for (int i = 0; i < n; ++i)
                {
                    DeliveryAndMerch delivery_merch2 = new DeliveryAndMerch();//dlaczego musi być tutaj obiekt zdefiniowany ?

                    delivery_merch2.dlv.date = Delivery_List[i].date;
                    delivery_merch2.dlv.delivery_number = Delivery_List[i].delivery_number;
                    delivery_merch2.dlv.realised = Delivery_List[i].realised;

                    delivery_merch2.mrc.amount = Merch_List[i].amount;
                    delivery_merch2.mrc.name = Merch_List[i].name;
                    delivery_merch2.mrc.unit = Merch_List[i].unit;

                    delivery_merch2.spl.city_name = Supplier_List[i].city_name;
                    delivery_merch2.spl.nip_number = Supplier_List[i].nip_number;
                    delivery_merch2.spl.street_name = Supplier_List[i].street_name;
                    delivery_merch2.spl.supplier_name = Supplier_List[i].supplier_name;

                    
                   DeliveryAndMerchList.Add(delivery_merch2);
                 //  DeliveryAndMerchListAll.Add(delivery_merch2); 
                }

                for (int i = 0; DeliveryAndMerchList.Count() > 5; ++i)
                    DeliveryAndMerchList.RemoveAt(DeliveryAndMerchList.Count() - 1);
                
               
            }
            
        }
        //
        public void LoadDeliveryAndMerchAll()
        {

            if (File.Exists(filepathmerch_all) && File.Exists(filepathdelivery_all) && File.Exists(filepathsupplier_all))
            {
                Merch_List_All = SerializeClass.DeserializeObject<ObservableCollection<Merch>>(filepathmerch_all);
                Delivery_List_All = SerializeClass.DeserializeObject<ObservableCollection<Delivery>>(filepathdelivery_all);
                Supplier_List_All = SerializeClass.DeserializeObject<ObservableCollection<Supplier>>(filepathsupplier_all);

                DeliveryAndMerchListAll.Clear();
                for (int i = 0; i < Merch_List_All.Count(); ++i)
                {
                    DeliveryAndMerch delivery_merch_all = new DeliveryAndMerch();

                    delivery_merch_all.dlv.date = Delivery_List_All[i].date;
                    delivery_merch_all.dlv.delivery_number = Delivery_List_All[i].delivery_number;
                    delivery_merch_all.dlv.realised = Delivery_List_All[i].realised;

                    delivery_merch_all.mrc.amount = Merch_List_All[i].amount;
                    delivery_merch_all.mrc.name = Merch_List_All[i].name;
                    delivery_merch_all.mrc.unit = Merch_List_All[i].unit;

                    delivery_merch_all.spl.city_name = Supplier_List_All[i].city_name;
                    delivery_merch_all.spl.nip_number = Supplier_List_All[i].nip_number;
                    delivery_merch_all.spl.street_name = Supplier_List_All[i].street_name;
                    delivery_merch_all.spl.supplier_name = Supplier_List_All[i].supplier_name;

                    
                    DeliveryAndMerchListAll.Add(delivery_merch_all);
                }
            }

        }
        //
        public void LoadDeliveryAndMerch_Delivery()
        {

            if (File.Exists(filepathmerch_D) && File.Exists(filepathdelivery_D) && File.Exists(filepathsupplier_D))
            {
                Merch_List_D = SerializeClass.DeserializeObject<List<Merch>>(filepathmerch_D);
                Delivery_List_D = SerializeClass.DeserializeObject<List<Delivery>>(filepathdelivery_D);
                Supplier_List_D = SerializeClass.DeserializeObject<List<Supplier>>(filepathsupplier_D);
              

                int n = Merch_List_D.Count();

                for (int i = 0; i < n; ++i)
                {
                    DeliveryAndMerch delivery_merch_D2 = new DeliveryAndMerch();//dlaczego musi być tutaj obiekt zdefiniowany ?

                    delivery_merch_D2.dlv.date = Delivery_List_D[i].date;
                    delivery_merch_D2.dlv.delivery_number = Delivery_List_D[i].delivery_number;
                    delivery_merch_D2.dlv.realised = Delivery_List_D[i].realised;

                    delivery_merch_D2.mrc.amount = Merch_List_D[i].amount;
                    delivery_merch_D2.mrc.name = Merch_List_D[i].name;
                    delivery_merch_D2.mrc.unit = Merch_List_D[i].unit;

                    delivery_merch_D2.spl.city_name = Supplier_List_D[i].city_name;
                    delivery_merch_D2.spl.nip_number = Supplier_List_D[i].nip_number;
                    delivery_merch_D2.spl.street_name = Supplier_List_D[i].street_name;
                    delivery_merch_D2.spl.supplier_name = Supplier_List_D[i].supplier_name;
                    
                    DeliveryAndMerchListDelivery.Add(delivery_merch_D2);
                }
            }
        }

        public void RemoveOrder()
        {
            if (selected_item != null)
            {
                DeliveryAndMerchList.Remove(selected_item);
              //  DeliveryAndMerchListAll.Remove(selected_item);
                /*
                XmlSerializer damxs = new XmlSerializer(typeof(ObservableCollection<DeliveryAndMerch>), "http://www.cpandl.com");
                using (StreamWriter damwr = new StreamWriter(filepathdeliveryandmerch))
                {
                    damxs.Serialize(damwr, DeliveryAndMerchList);
                }*/     
                Delivery_List.Clear();
                Merch_List.Clear();
                Supplier_List.Clear();
                
                for (int i = 0; i<DeliveryAndMerchList.Count; ++i )
                {
                    Delivery_List.Insert(i, DeliveryAndMerchList[i].dlv); 
                    Merch_List.Insert(i,DeliveryAndMerchList[i].mrc); 
                    Supplier_List.Insert(i, DeliveryAndMerchList[i].spl);
                } 

                SerializeClass.SerializeObject(Merch_List, filepathmerch);
                SerializeClass.SerializeObject(Delivery_List, filepathdelivery);
                SerializeClass.SerializeObject(Supplier_List, filepathsupplier);
            }
        }
        
        public void RemoveOrderAll()
        {
            if (selected_item != null)
            {
                DeliveryAndMerchListAll.Remove(selected_item);

                Delivery_List_All.Clear();
                Merch_List_All.Clear();
                Supplier_List_All.Clear();

                for (int i = 0; i < DeliveryAndMerchListAll.Count; ++i)
                {
                    Delivery_List_All.Insert(i, DeliveryAndMerchListAll[i].dlv);
                    Merch_List_All.Insert(i, DeliveryAndMerchListAll[i].mrc);
                    Supplier_List_All.Insert(i, DeliveryAndMerchListAll[i].spl);
                } 

                SerializeClass.SerializeObject(Merch_List_All, filepathmerch_all);
                SerializeClass.SerializeObject(Delivery_List_All, filepathdelivery_all);
                SerializeClass.SerializeObject(Supplier_List_All, filepathsupplier_all);
            }
        }

        public void RemoveDelivery()
        {
            if (selected_item != null)
            {
                DeliveryAndMerchListDelivery.Remove(selected_item);

                Delivery_List_D.Clear();
                Merch_List_D.Clear();
                Supplier_List_D.Clear();
                /*
                XmlSerializer damxs = new XmlSerializer(typeof(ObservableCollection<DeliveryAndMerch>), "http://www.cpandl.com");
                using (StreamWriter damwr = new StreamWriter(filepathdeliveryandmerch2))
                {
                    damxs.Serialize(damwr, DeliveryAndMerchListDelivery);
                }*/

                for (int i = 0; i < DeliveryAndMerchListDelivery.Count; ++i)
                {
                    Delivery_List_D.Insert(i, DeliveryAndMerchListDelivery[i].dlv);
                    Merch_List_D.Insert(i, DeliveryAndMerchListDelivery[i].mrc);
                    Supplier_List_D.Insert(i, DeliveryAndMerchListDelivery[i].spl);
                }

                SerializeClass.SerializeObject(Merch_List_D, filepathmerch_D);
                SerializeClass.SerializeObject(Delivery_List_D, filepathdelivery_D);
                SerializeClass.SerializeObject(Supplier_List_D, filepathsupplier_D);
            }
        }
      
        public void SerializeObject_NewSupplier()
        {
            DeliveryAndMerch delivery_merch = new DeliveryAndMerch();

            Supplier s = new Supplier() { supplier_guid = Guid.NewGuid() };
           // Merch m = new Merch() { merch_guid = Guid.NewGuid(), supplier_guid = s.supplier_guid };
           // Delivery d = new Delivery() { delivery_guid = Guid.NewGuid(), supplier_guid = s.supplier_guid};
            
            s.supplier_name = supplier.supplier_name;
            s.city_name = supplier.city_name;
            s.street_name = supplier.street_name;
            s.nip_number = supplier.nip_number;
            /*
            m.name = merch.name;
            m.amount = merch.amount;
            m.unit = merch.unit;
            
            d.date = delivery.date;
            d.delivery_number = delivery.delivery_number;
            d.realised = delivery.realised;
            */
            /*
            delivery_merch.mrc.name = m.name;
            delivery_merch.mrc.amount = m.amount;
            delivery_merch.mrc.unit = m.unit;
            
            delivery_merch.spl.supplier_name = s.supplier_name;
            delivery_merch.spl.city_name = s.city_name;
            delivery_merch.spl.street_name = s.street_name;
            delivery_merch.spl.nip_number = s.nip_number;
             
            delivery_merch.dlv.date = d.date;
            delivery_merch.dlv.delivery_number = d.delivery_number;
            delivery_merch.dlv.realised = d.realised;
       
            DeliveryAndMerchList.Insert(0, delivery_merch);
    */
         //   Merch_List.Insert(0,m);
            //Delivery_List.Insert(0,d);
           // Supplier_List.Insert(0,s);
            
          //  Merch_List_All.Insert(0, m);
            //Delivery_List_All.Insert(0, d);
          //  Supplier_List_All.Insert(0, s);
            
            int j = 0;

            for(int i=0; i < Suppliers_List.Count(); ++i)
            {
                if (Suppliers_List[i].supplier_name == s.supplier_name)
                    ++j;       
            }
            
            if(j==0)
                Suppliers_List.Insert(0, s);

           // for (int i = 0; DeliveryAndMerchList.Count() > 5; ++i)
             //   DeliveryAndMerchList.RemoveAt(DeliveryAndMerchList.Count() - 1);
            
           // SerializeClass.SerializeObject(Merch_List,filepathmerch);
            //SerializeClass.SerializeObject(Delivery_List, filepathdelivery);
          //  SerializeClass.SerializeObject(Supplier_List, filepathsupplier);

          //  SerializeClass.SerializeObject(Merch_List_All, filepathmerch_all);
         //   SerializeClass.SerializeObject(Delivery_List_All, filepathdelivery_all);
          //  SerializeClass.SerializeObject(Supplier_List_All, filepathsupplier_all);

            SerializeClass.SerializeObject(Suppliers_List, filepathsupplierslist);

        //    DeliveryAndMerchListAll.Insert(0, delivery_merch);

         //   if (!merchlist.Contains(merch.name))
           //     merchlist.Add(merch.name);

           // SerializeClass.SerializeObject(merchlist, filepathmerchlist);
            
            if (!Suppliers.Contains(supplier.supplier_name))
                Suppliers.Add(supplier.supplier_name);

            SerializeClass.SerializeObject(Suppliers, filepathsuppliers);
            
            if (!Cities.Contains(supplier.city_name))
                Cities.Add(supplier.city_name);

            SerializeClass.SerializeObject(Cities, filepathcities);

            if (!Streets.Contains(supplier.street_name))
                Streets.Add(supplier.street_name);

            SerializeClass.SerializeObject(Streets, filepathstreets);
        }

        public void SerializeObject_NewOrder()
        {
            DeliveryAndMerch delivery_merch = new DeliveryAndMerch();

            Supplier s = new Supplier() { supplier_guid = Guid.NewGuid() };
            Merch m = new Merch() { merch_guid = Guid.NewGuid(), supplier_guid = s.supplier_guid };
            Delivery d = new Delivery() { delivery_guid = Guid.NewGuid(), supplier_guid = s.supplier_guid };
           
            s.supplier_name = supplier_for_list.supplier_name;
            s.city_name = supplier_for_list.city_name;
            s.street_name = supplier_for_list.street_name;
            s.nip_number = supplier_for_list.nip_number;
            

            m.name = merch.name;
            m.amount = merch.amount;
            m.unit = merch.unit;

            d.date = delivery.date;
            d.delivery_number = delivery.delivery_number;
            d.realised = delivery.realised;

            delivery_merch.mrc.name = m.name;
            delivery_merch.mrc.amount = m.amount;
            delivery_merch.mrc.unit = m.unit;

            delivery_merch.spl.supplier_name = s.supplier_name;
            delivery_merch.spl.city_name = s.city_name;
            delivery_merch.spl.street_name = s.street_name;
            delivery_merch.spl.nip_number = s.nip_number;

            delivery_merch.dlv.date = d.date;
            //  delivery_merch.spl.nip_number = s.nip_number;
            delivery_merch.dlv.delivery_number = d.delivery_number;
            delivery_merch.dlv.realised = d.realised;

            DeliveryAndMerchList.Insert(0, delivery_merch);

            Merch_List.Insert(0, m);
            Delivery_List.Insert(0, d);
            Supplier_List.Insert(0, s);

            Merch_List_All.Insert(0, m);
            Delivery_List_All.Insert(0, d);
            Supplier_List_All.Insert(0, s);
            /*
            int j = 0;

            for (int i = 0; i < Suppliers_List.Count(); ++i)
            {
                if (Suppliers_List[i].supplier_name == s.supplier_name)
                    ++j;
            }

            if (j == 0)
                Suppliers_List.Insert(0, s);
            */
            for (int i = 0; DeliveryAndMerchList.Count() > 5; ++i)
                DeliveryAndMerchList.RemoveAt(DeliveryAndMerchList.Count() - 1);

            SerializeClass.SerializeObject(Merch_List, filepathmerch);
            SerializeClass.SerializeObject(Delivery_List, filepathdelivery);
            SerializeClass.SerializeObject(Supplier_List, filepathsupplier);

            SerializeClass.SerializeObject(Merch_List_All, filepathmerch_all);
            SerializeClass.SerializeObject(Delivery_List_All, filepathdelivery_all);
            SerializeClass.SerializeObject(Supplier_List_All, filepathsupplier_all);

        //    SerializeClass.SerializeObject(Suppliers_List, filepathsupplierslist);

            DeliveryAndMerchListAll.Insert(0, delivery_merch);

            if (!merchlist.Contains(merch.name))
                merchlist.Add(merch.name);

            SerializeClass.SerializeObject(merchlist, filepathmerchlist);
/*
            if (!Suppliers.Contains(supplier.supplier_name))
                Suppliers.Add(supplier.supplier_name);

            SerializeClass.SerializeObject(Suppliers, filepathsuppliers);
            
            if (!Cities.Contains(supplier.city_name))
                Cities.Add(supplier.city_name);

            SerializeClass.SerializeObject(Cities, filepathcities);

            if (!Streets.Contains(supplier.street_name))
                Streets.Add(supplier.street_name);

            SerializeClass.SerializeObject(Streets, filepathstreets);*/
        }

        public void SerializeObjectDelivery()
        {
            DeliveryAndMerch delivery_merch_D = new DeliveryAndMerch();

            Supplier s = new Supplier() { supplier_guid = Guid.NewGuid() };
            Merch m = new Merch() { merch_guid = Guid.NewGuid(), supplier_guid = s.supplier_guid };
            Delivery d = new Delivery() { delivery_guid = Guid.NewGuid(), supplier_guid = s.supplier_guid };

            m.name = merch.name;
            m.amount = merch.amount;
            m.unit = merch.unit;

            d.date = delivery.date;
            d.delivery_number = delivery.delivery_number;
            d.realised = delivery.realised;

            s.supplier_name = supplier.supplier_name;
            s.city_name = supplier.city_name;
            s.street_name = supplier.street_name;
            s.nip_number = supplier.nip_number;

            delivery_merch_D.mrc.name = merch.name;
            delivery_merch_D.mrc.amount = merch.amount;
            delivery_merch_D.mrc.unit = merch.unit;
            delivery_merch_D.spl.supplier_name = supplier.supplier_name;
            delivery_merch_D.spl.city_name = supplier.city_name;
            delivery_merch_D.spl.street_name = supplier.street_name;
            delivery_merch_D.dlv.date = delivery.date;
            delivery_merch_D.spl.nip_number = supplier.nip_number;
            delivery_merch_D.dlv.delivery_number = delivery.delivery_number;
            delivery_merch_D.dlv.realised = delivery.realised;

            DeliveryAndMerchListDelivery.Insert(0, delivery_merch_D);
            Merch_List_D.Insert(0, m);
            Delivery_List_D.Insert(0, d);
            Supplier_List_D.Insert(0, s);

            SerializeClass.SerializeObject(Merch_List_D, filepathmerch_D);
            SerializeClass.SerializeObject(Delivery_List_D, filepathdelivery_D);
            SerializeClass.SerializeObject(Supplier_List_D, filepathsupplier_D);
        }
        
        public void SaveStatus()
        {
            for (int i = 0; i < DeliveryAndMerchList.Count(); ++i)
            {
                Delivery_List[i].realised = DeliveryAndMerchList[i].dlv.realised;
              //  if(DeliveryAndMerchListAll)
                Delivery_List_All[i].realised = DeliveryAndMerchList[i].dlv.realised;
           
            }

            SerializeClass.SerializeObject(Delivery_List, filepathdelivery);
            SerializeClass.SerializeObject(Delivery_List_All, filepathdelivery_all);
        }

    }
}
