using SomerenService;
using SomerenModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
            InitializePanelComponents();
        }

        private void InitializePanelComponents()
        {
            InitializeDateTimePicker();
            ShowDashboardPanel();
            UpdatePriceInOrder();
            DateInRevenueChanged();
            DisplayVatInVatPanel();
        }

        /*Dashboard panel*/

        private void ShowDashboardPanel()
        {
            HideAll();
            pnlDashboard.Show();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            ShowDashboardPanel();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        /*Students panel*/

        private void ShowStudentsPanel()
        {
            HideAll();
            pnlStudents.Show();

            try
            {
                List<Student> students = GetStudents();
                DisplayStudents(students, "student");
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);
            }
        }

        private List<Student> GetStudents()
        {
            StudentService studentService = new();
            return studentService.GetStudents();
        }

        private void DisplayStudents(List<Student> students, string checkpanel)
        {
            listViewStudents.Items.Clear();

            Action<ListViewItem> addItem = AddStudent(checkpanel);

            foreach (Student student in students)
            {
                ListViewItem item = new();
                item.SubItems.Add(student.PersonID.ToString());
                item.SubItems.Add(student.FullName);
                item.SubItems.Add(student.ClassName);
                item.SubItems.Add(student.PhoneNumber);
                item.SubItems.Add(student.RoomNumber.ToString());
                item.Tag = student;

                addItem(item);
            }
        }

        private Action<ListViewItem> AddStudent(string checkPanel)
        {
            Action<ListViewItem> addItem;

            switch (checkPanel)
            {
                case "student":
                    addItem = item => listViewStudents.Items.Add(item);
                    break;

                case "NotParticipant":
                    addItem = item => listViewNotParticipants.Items.Add(item);
                    break;

                default:
                    addItem = item => listViewParticipants.Items.Add(item);
                    break;
            }

            return addItem;
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStudentsPanel();
        }

        private void deleteStudentButton_Click(object sender, EventArgs e)
        {
            if (listViewStudents.SelectedItems.Count != 0)
            {
                DeleteStudent();
            }
            else
            {
                MessageBox.Show("Select a student!");
            }
        }

        private void DeleteStudent()
        {
            ListViewItem selectedStudent = listViewStudents.SelectedItems[0];

            if (CreateDeleteCheckForm("Are you sure you wish to remove this student?").DeleteMessage())
            {
                StudentService studentService = new();
                studentService.DeleteStudent((Student)selectedStudent.Tag);

                ShowStudentsPanel();
                MessageBox.Show("Student deleted!");
            }
            else
            {
                MessageBox.Show("Action canceled!");
            }
        }

        private void openStudentAddForm_Click(object sender, EventArgs e)
        {
            OpenStudentAddForm();
        }

        private void OpenStudentAddForm()
        {
            AddStudentForm studentAddForm = new();
            studentAddForm.ShowDialog();
            ShowStudentsPanel();
        }

        private void openStudentUpdateButton_Click(object sender, EventArgs e)
        {
            if (listViewStudents.SelectedItems.Count != 0)
            {
                OpenUpdateStudentForm();
            }
            else
            {
                MessageBox.Show("Select a student!");
            }
        }

        private void OpenUpdateStudentForm()
        {
            ListViewItem selectedStudent = listViewStudents.SelectedItems[0];

            UpdateStudentForm studentUpdateForm = new((Student)selectedStudent.Tag);
            studentUpdateForm.ShowDialog();
            ShowStudentsPanel();
        }

        /*Lecturers panel*/

        private void ShowLecturersPanel()
        {
            HideAll();
            pnlLecturers.Show();

            try
            {
                List<Lecturer> lecturers = GetLecturers();
                DisplayLecturers(lecturers, "lecturer");
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);
            }
        }

        private List<Lecturer> GetLecturers()
        {
            LecturerService lecturerService = new();
            return lecturerService.GetLecturers();
        }

        private void DisplayLecturers(List<Lecturer> lecturers, string checkPanel)
        {
            listViewLecturers.Items.Clear();
            Action<ListViewItem> addItem = AddLecturer(checkPanel);

            foreach (var lecturer in lecturers)
            {
                ListViewItem item = new(lecturer.PersonID.ToString());
                item.SubItems.Add(lecturer.FullName);
                item.SubItems.Add(lecturer.Age.ToString("dd-MM-yyyy"));
                item.SubItems.Add(lecturer.PhoneNumber);
                item.SubItems.Add(lecturer.RoomNumber.ToString());
                item.Tag = lecturer;

                addItem(item);
            }
        }

        private Action<ListViewItem> AddLecturer(string checkPanel)
        {
            Action<ListViewItem> addItem;

            switch (checkPanel)
            {
                case "lecturer":
                    addItem = item => listViewLecturers.Items.Add(item);
                    break;

                case "notsupervisoractivity":
                    addItem = item => listNotActivitySupervisor.Items.Add(item);
                    break;

                default:
                    addItem = item => listViewSupervisor.Items.Add(item);
                    break;
            }

            return addItem;
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLecturersPanel();
        }

        private void deleteLecturerButton_Click(object sender, EventArgs e)
        {
            if (listViewLecturers.SelectedItems.Count != 0)
            {
                DeleteLecturer();
            }
            else
            {
                MessageBox.Show("Select a lecturer!");
            }
        }

        private void DeleteLecturer()
        {
            ListViewItem selectedLecturer = listViewLecturers.SelectedItems[0];

            if (CreateDeleteCheckForm("Are you sure you wish to remove this lecturer?").DeleteMessage())
            {
                LecturerService lecturerService = new();
                lecturerService.DeleteLecturer((Lecturer)selectedLecturer.Tag);

                ShowLecturersPanel();
                MessageBox.Show("Lecturer deleted!");
            }
            else
            {
                MessageBox.Show("Aaction canceled!");
            }
        }

        private void openAddLecturerPanel_Click(object sender, EventArgs e)
        {
            OpenAddLecturerForm();
        }

        private void OpenAddLecturerForm()
        {
            AddLecturerForm addLecturerForm = new();
            addLecturerForm.ShowDialog();
            ShowLecturersPanel();
        }

        private void openUpdateLecturerpanel_Click(object sender, EventArgs e)
        {
            if (listViewLecturers.SelectedItems.Count != 0)
            {
                OpenUpdateLecturerForm();
            }
            else
            {
                MessageBox.Show("Select a lecturer!");
            }
        }

        private void OpenUpdateLecturerForm()
        {
            ListViewItem selectedLecturer = listViewLecturers.SelectedItems[0];

            UpdateLecturerForm LecturerUpdateForm = new((Lecturer)selectedLecturer.Tag);
            LecturerUpdateForm.ShowDialog();
            ShowLecturersPanel();
        }

        /*Rooms panel*/

        private void ShowRoomsPanel()
        {
            HideAll();
            panelRooms.Show();

            try
            {
                List<Room> rooms = GetRooms();
                DisplayRooms(rooms);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the rooms: " + e.Message);
            }
        }

        private List<Room> GetRooms()
        {
            RoomService roomService = new();
            return roomService.GetRooms();
        }

        private void DisplayRooms(List<Room> rooms)
        {
            listViewRooms.Items.Clear();

            foreach (Room room in rooms)
            {
                ListViewItem item = new();
                item.SubItems.Add(room.Number.ToString());
                item.SubItems.Add(room.Building);
                item.SubItems.Add(room.Capacity.ToString());
                item.SubItems.Add(room.Floor.ToString());
                item.Tag = room;

                listViewRooms.Items.Add(item);
            }
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRoomsPanel();
        }

        /*Activity panel*/

        private void ShowActivitiesPanel()
        {
            HideAll();
            pnlActivities.Show();

            try
            {
                List<Activity> activities = GetActivities();
                DisplayActivities(activities, "activity");
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the activities: " + e.Message);
            }
        }

        private List<Activity> GetActivities()
        {
            ActivityService activityService = new ActivityService();
            return activityService.GetActivities();
        }

        private void DisplayActivities(List<Activity> activities, string checkpanel)
        {
            listViewActivities.Items.Clear();
            Action<ListViewItem> addItem = AddActivity(checkpanel);

            foreach (Activity activity in activities)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(activity.ActivityID.ToString());
                item.SubItems.Add(activity.Name);
                item.SubItems.Add(activity.StartDayTime.ToString());
                item.SubItems.Add(activity.EndDayTime.ToString());
                item.Tag = activity;
                addItem(item);
            }
        }

        private Action<ListViewItem> AddActivity(string checkPanel)
        {
            Action<ListViewItem> addItem;

            switch (checkPanel)
            {
                case "activity":
                    addItem = item => listViewActivities.Items.Add(item);
                    break;

                case "supervisor":
                    addItem = item => listActivitiesView.Items.Add(item);
                    break;

                default:
                    addItem = item => listViewActivitiesForParticipants.Items.Add(item);
                    break;
            }

            return addItem;
        }

        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowActivitiesPanel();
        }

        /*Drink panel*/

        private void ShowDrinksPanel()
        {
            HideAll();
            pnlDrinks.Show();

            try
            {
                List<Drink> drink = GetDrinks();
                DisplayDrinks(drink);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the drink: " + e.Message);
            }
        }

        private List<Drink> GetDrinks()
        {
            DrinkService drinkService = new();
            return drinkService.GetDrinks();
        }

        private void DisplayDrinks(List<Drink> drinks)
        {
            listViewDrinks.Items.Clear();

            foreach (Drink drink in drinks)
            {
                ListViewItem li = new();
                li.SubItems.Add(drink.Drink_ID.ToString());
                li.SubItems.Add(drink.Name);
                li.SubItems.Add("€" + drink.Price.ToString());
                li.SubItems.Add(drink.StockToText);
                li.SubItems.Add(drink.Vat.ToString() + "%");
                li.Tag = drink;

                listViewDrinks.Items.Add(li);
            }
        }

        private void drinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDrinksPanel();
        }

        private void btnDrinkDelete_Click(object sender, EventArgs e)
        {
            if (listViewDrinks.SelectedItems.Count != 0)
            {
                DeleteDrink();
            }
            else
            {
                MessageBox.Show("Select a drink!");
            }
        }

        private void DeleteDrink()
        {
            ListViewItem selectedDrink = listViewDrinks.SelectedItems[0];
            DrinkService drinkService = new();
            drinkService.DeleteDrink((Drink)selectedDrink.Tag);
            ShowDrinksPanel();

            MessageBox.Show("Drink deleted!");
        }

        private void btnDrinkAdd_Click(object sender, EventArgs e)
        {
            OpenDrinkAddForm();
        }

        private void OpenDrinkAddForm()
        {
            DrinkAddForm drinkAddForm = new();
            drinkAddForm.ShowDialog();
            ShowDrinksPanel();
        }

        private void btnUpdateDrink_Click(object sender, EventArgs e)
        {
            if (listViewDrinks.SelectedItems.Count != 0)
            {
                OpenDrinkUpdateForm();
            }
            else
            {
                MessageBox.Show("Select a drink!");
            }
        }

        private void OpenDrinkUpdateForm()
        {
            ListViewItem selectedDrink = listViewDrinks.SelectedItems[0];

            DrinkUpdateForm drinkUpdateForm = new((Drink)selectedDrink.Tag);

            drinkUpdateForm.ShowDialog();
            ShowDrinksPanel();
        }

        /*Order panel*/

        private void ShowOrderPanel()
        {
            HideAll();
            ClearOrderPanel();
            pnlOrder.Show();

            try
            {
                List<Student> students = GetStudents();
                List<Drink> drinks = GetDrinks();
                DisplayDrinksForOrder(drinks);
                DisplayStudentsForOrder(students);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the drink: " + e.Message);
            }
        }

        private void DisplayStudentsForOrder(List<Student> students)
        {
            listViewOrderStudent.Items.Clear();

            foreach (Student student in students)
            {
                ListViewItem item = new();
                item.SubItems.Add(student.PersonID.ToString());
                item.SubItems.Add(student.FullName);
                item.Tag = student;

                listViewOrderStudent.Items.Add(item);
            }
        }

        private void DisplayDrinksForOrder(List<Drink> drinks)
        {
            listViewOrderDrink.Items.Clear();

            foreach (Drink drink in drinks)
            {
                ListViewItem item = new();
                item.SubItems.Add(drink.Name);
                item.SubItems.Add("€" + drink.Price.ToString());
                item.SubItems.Add(drink.Alcohol);
                item.SubItems.Add(drink.Stock.ToString());
                item.Tag = drink;

                listViewOrderDrink.Items.Add(item);
            }
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrderPanel();
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            try
            {
                PlaceOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearOrderPanel()
        {
            quantityOfDrinks.Value = quantityOfDrinks.Minimum;
            PriceOutputLabel.Text = "";
        }

        private void PlaceOrder()
        {
            ChooseStudentDrinkError();
            FillOrder();
            ShowOrderPanel();
            MessageBox.Show("Order is successfully placed!");
        }

        private void ChooseStudentDrinkError()
        {
            if (listViewOrderStudent.SelectedItems.Count == 0)
            {
                throw new Exception("Select a student!");
            }
            else if (listViewOrderDrink.SelectedItems.Count == 0)
            {
                throw new Exception("Select a drink!");
            }
        }

        private void FillOrder()
        {
            OrderService orderService = new();
            ListViewItem selectedDrink = listViewOrderDrink.SelectedItems[0];
            ListViewItem selectedStudent = listViewOrderStudent.SelectedItems[0];

            orderService.FillOrder((Student)selectedStudent.Tag, (Drink)selectedDrink.Tag, (int)quantityOfDrinks.Value);
        }

        private void UpdatePriceInOrder()
        {
            foreach (Control control in pnlOrder.Controls)
            {
                if (control is ListView listView)
                {
                    listView.SelectedIndexChanged += (sender, e) => DisplayOrderPrice();
                }
                else if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.ValueChanged += (sender, e) => DisplayOrderPrice();
                }
            }
        }

        private void DisplayOrderPrice()
        {
            if (listViewOrderDrink.SelectedItems.Count > 0 && listViewOrderStudent.SelectedItems.Count > 0)
            {
                OrderService orderService = new();
                ListViewItem selectedDrink = listViewOrderDrink.SelectedItems[0];
                orderService.DisplayPrice((Drink)selectedDrink.Tag, quantityOfDrinks.Value, out string totalPrice);
                PriceOutputLabel.Text = totalPrice;
            }
        }

        /*Revenue panel*/

        private void ShowRevenuePanel()
        {
            HideAll();
            pnlRevenue.Show();

            try
            {
                List<Order> orders = GetOrders();
                DisplayAllFields(orders);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the drink: " + e.Message);
            }
        }

        private List<Order> GetOrders()
        {
            OrderService orderService = new();
            return orderService.GetOrders();
        }

        private void revenueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRevenuePanel();
        }

        private void DateInRevenueChanged()
        {
            foreach (Control control in pnlRevenue.Controls)
            {
                if (control is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.ValueChanged += (sender, e) => ShowOrders();
                }
            }
        }

        private void ShowOrders()
        {
            ClearAllLitsts();

            OrderService orderService = new();

            try
            {
                if (orderService.RightDates(dateTimePickerStart.Value, dateTimePickerEnd.Value))
                {
                    List<Order> orders = GetOrders();
                    DisplayAllFields(orders);
                }
                else
                {
                    throw new Exception("Choose the right date!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplaySeparateSales(List<Order> orders)
        {
            listViewDrinksSold.Items.Clear();

            foreach (var order in orders)
            {
                if (order.OrderDate >= dateTimePickerStart.Value && order.OrderDate <= dateTimePickerEnd.Value)
                {
                    ListViewItem item = new();
                    item.SubItems.Add(order.Drink.Name);
                    item.SubItems.Add(order.Drink.Price.ToString());
                    item.SubItems.Add(order.Quantity.ToString());
                    item.Tag = order;

                    listViewDrinksSold.Items.Add(item);
                }
            }
        }

        private void ClearAllLitsts()
        {
            listViewDrinksSold.Items.Clear();
            TotalSalesLabel.Text = string.Empty;
            Turnoverlabel.Text = string.Empty;
            NumOfCustomersLabel.Text = string.Empty;
        }

        private void DisplayAllFields(List<Order> orders)
        {
            OrderService orderService = new();

            DisplaySeparateSales(orders);
            orderService.DisplayTotalSales(orders, dateTimePickerStart.Value, dateTimePickerEnd.Value, out string totalSales);
            orderService.DisplayTurnover(orders, dateTimePickerStart.Value, dateTimePickerEnd.Value, out string turnover);
            orderService.DisplayNumberOfCustomers(dateTimePickerStart.Value, dateTimePickerEnd.Value, out string numberOfCustomers);

            NumOfCustomersLabel.Text = numberOfCustomers;
            Turnoverlabel.Text = turnover;
            TotalSalesLabel.Text = totalSales;
        }

        private void InitializeDateTimePicker()
        {
            dateTimePickerStart.MaxDate = DateTime.Today;
            dateTimePickerEnd.MaxDate = DateTime.Today;

            dateTimePickerEnd.Value = DateTime.Today;
            dateTimePickerStart.Value = DateTime.Today;
        }

        /*VAT panel*/

        private void ShowVATPanel()
        {
            HideAll();
            pnlVAT.Show();
        }

        private void VATInformationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowVATPanel();
        }

        private void DisplayVatInVatPanel()
        {
            foreach (Control control in pnlVAT.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    int quarterNumber = Convert.ToInt32(radioButton.Tag);

                    radioButton.CheckedChanged += (sender, e) => ShowVatInformation(quarterNumber);
                }
            }
        }

        private void ShowVatInformation(int quarterNumber)
        {
            try
            {
                OrderService orderService = new();
                orderService.VatInformation(int.Parse(YearTextBoxVAT.Text), quarterNumber, out VatInformation information);
                ShowTextToElements(information);
            }
            catch (Exception)
            {
                MessageBox.Show("Entered year is not in the right format");
            }
        }

        private void ShowTextToElements(VatInformation information)
        {
            StartQuarterLabel.Text = information.StartDate.ToString("dd-MM-yyyy");
            EndQuarterLabel.Text = information.EndDate.ToString("dd-MM-yyyy");
            Vat9Label.Text = information.Vat9;
            Vat21Label.Text = information.Vat21;
            VatTotalLabel.Text = information.TotalVat;
        }

        /*SupervisorPanel*/

        private void toolStripSupervisors_Click(object sender, EventArgs e)
        {
            ShowSupervisorsPanel();
        }

        private void ShowSupervisorsPanel()
        {
            HideAll();
            listActivitiesView.Items.Clear();
            pnlSupervisors.Show();

            try
            {
                List<Activity> activities = GetActivities();
                DisplayActivities(activities, "supervisor");
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the activities: " + e.Message);
            }
        }

        private void BShowSupervisors_Click(object sender, EventArgs e)
        {
            ShowSupervisorsForActivity();
        }

        private void ShowSupervisorsForActivity()
        {
            listViewSupervisor.Items.Clear();
            listNotActivitySupervisor.Items.Clear();

            if (IsActivitySelected())
            {
                DisplayActivitySupervisors();
            }
            else
            {
                MessageBox.Show("Activity wasn't chosen!");
            }
        }

        private bool IsActivitySelected()
        {
            return listActivitiesView.SelectedItems.Count != 0;
        }

        private void DisplayActivitySupervisors()
        {
            ListViewItem selectedActivity = listActivitiesView.SelectedItems[0];
            LecturerService lecturerService = new();

            List<Lecturer> activityLecturers = lecturerService.ShowActivitySupervisors((Activity)selectedActivity.Tag, true);
            DisplayLecturers(activityLecturers, "supervisor");

            List<Lecturer> notActivityLecturers = lecturerService.ShowActivitySupervisors((Activity)selectedActivity.Tag, false);
            DisplayLecturers(notActivityLecturers, "notsupervisoractivity");
        }

        private void BDeleteSupervisors_Click(object sender, EventArgs e)
        {
            DeleteSupervisor();
        }

        private void DeleteSupervisor()
        {
            if (!IsSupervisorSelected())
            {
                MessageBox.Show("Supervisor wasn't chosen!");
                return;
            }

            if (ConfirmDelete())
            {
                DeleteSelectedSupervisor();
                MessageBox.Show("Supervisor deleted!");
            }
            else
            {
                MessageBox.Show("Action canceled!");
            }
        }

        private bool IsSupervisorSelected()
        {
            return listViewSupervisor.SelectedItems.Count > 0;
        }

        private bool ConfirmDelete()
        {
            return CreateDeleteCheckForm("Are you sure you wish to remove this supervisor?").DeleteMessage();
        }

        private void DeleteSelectedSupervisor()
        {
            ListViewItem selectedSupervisor = listViewSupervisor.SelectedItems[0];
            LecturerService supervisorService = new();
            supervisorService.DeleteSupervisor((Lecturer)selectedSupervisor.Tag);
            listViewSupervisor.Items.Remove(selectedSupervisor);
            listNotActivitySupervisor.Items.Add(selectedSupervisor);
            ShowSupervisorsPanel();
        }

        private void BAddSupervisors_Click(object sender, EventArgs e)
        {
            OpenAddSupervisorForm();
        }

        private void OpenAddSupervisorForm()
        {
            AddSupervisorForm supervisorForm = new();
            supervisorForm.ShowDialog();
            ShowSupervisorsPanel();
        }

        //Participants panel

        private void toolStripParticipants_Click(object sender, EventArgs e)
        {
            ShowParticipantsPanel();
        }

        private void ShowParticipantsPanel()
        {
            HideAll();
            listViewActivitiesForParticipants.Items.Clear();
            pnlParticipants.Show();

            try
            {
                List<Activity> activities = GetActivities();
                DisplayActivities(activities, "participant");
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the activities: " + e.Message);
            }
        }

        private void btnShowParticipants_Click(object sender, EventArgs e)
        {
            ShowParticipantsForActivity();
        }

        private void ShowParticipantsForActivity()
        {
            listViewParticipants.Items.Clear();
            listViewNotParticipants.Items.Clear();

            if (listViewActivitiesForParticipants.SelectedItems.Count != 0)
            {
                DisplayActivityParticipants();
            }
            else
            {
                MessageBox.Show("Activity wasn't chosen!");
            }
        }

        private void DisplayActivityParticipants()
        {
            ListViewItem selectedActivity = listViewActivitiesForParticipants.SelectedItems[0];
            StudentService studentService = new();

            List<Student> activityParticipants = studentService.ShowActivityParticipants((Activity)selectedActivity.Tag, true);
            DisplayStudents(activityParticipants, "participant");

            List<Student> notActivityParticipants = studentService.ShowActivityParticipants((Activity)selectedActivity.Tag, false);
            DisplayStudents(notActivityParticipants, "NotParticipant");
        }

        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            if (listViewNotParticipants.SelectedItems.Count == 0 || listViewActivitiesForParticipants.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select activity and student that does not participate");
            }
            else
            {
                AddParticipant();
            }
        }

        private void AddParticipant()
        {
            try
            {
                ListViewItem selectedActivity = listViewActivitiesForParticipants.SelectedItems[0];
                ListViewItem selectedStudent = listViewNotParticipants.SelectedItems[0];
                CheckStudentInActivity((Student)selectedStudent.Tag, (Activity)selectedActivity.Tag);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while loading the activities: " + ex.Message);
            }
        }

        private void CheckStudentInActivity(Student student, Activity activity)
        {
            ActivityService activityService = new();
            StudentService studentService = new();

            if (activityService.CheckStudentInActivity(student, activity))
            {
                studentService.AddParticipant(student, activity);
                MessageBox.Show("Participant added!");
            }
            else
            {
                MessageBox.Show("Student cannot participate two activities at the same time!");
            }
        }

        private void btnDeleteParticipant_Click(object sender, EventArgs e)
        {
            if (listViewParticipants.SelectedItems.Count == 0 || listViewActivitiesForParticipants.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a participant and activity");
            }
            else
            {
                DeleteParticipant();
            }
        }

        private void DeleteParticipant()
        {
            try
            {
                ListViewItem selectedStudent = listViewParticipants.SelectedItems[0];
                ListViewItem selectedActivity = listViewActivitiesForParticipants.SelectedItems[0];
                CheckDeleteParticipant(selectedStudent, selectedActivity);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while loading the activities: " + ex.Message);
            }
        }

        private void CheckDeleteParticipant(ListViewItem selectedStudent, ListViewItem selectedActivity)
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to delete participant?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                StudentService studentService = new();
                studentService.DeleteParticipant((Student)selectedStudent.Tag, (Activity)selectedActivity.Tag);
                MessageBox.Show("Participant deleted!");
            }
            else
            {
                return;
            }
        }

        /*Else*/

        private void HideAll()
        {
            foreach (Control control in Controls)
            {
                if (control is Panel)
                {
                    control.Hide();
                }
            }
        }

        private DeleteConfirmationForm CreateDeleteCheckForm(string message)
        {
            DeleteConfirmationForm deleteCheckForm = new(message);
            deleteCheckForm.ShowDialog();

            return deleteCheckForm;
        }

        private void pnlVAT_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Vat9Label_Click(object sender, EventArgs e)
        {

        }

        private void Vat21Label_Click(object sender, EventArgs e)
        {

        }

        private void VatTotalLabel_Click(object sender, EventArgs e)
        {

        }

        private void listViewRooms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}