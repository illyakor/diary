using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TRPO
{
    public partial class AIForm : Form
    {
        int counter;
        string[,] bufData;
        string[,] additionalInf = new string[10, 29];
        int i = 0, k = 0, count = 0;
        string[] headerColumn = { "Номер класса : ", "Буква класса : ", "Государственное учереждение образования : ", "Телефон школы : ", "Домашний телефон : ", "ФИО Директора : ", "Номер директора : ", "ФИО заведующего : ", "Номер заведующего : ", "ФИО классного руководителя : ", "Номер классного руководителя : ", "ФИО социального педагога-психолога : ", "Номер социального педагога-психолога : ", "Замечания классного руководителя : ", "Рекомендации / Падзяки / Узнагароды : ", "АДРЕС ШКОЛЫ: Область / Областной центр : ", "Район / Районный центр : ", "Населённый пункт : ", "Улица : ", "Дом : ", "ДОМАШНИЙ АДРЕС: Область / Областной центр : ", "Район / Районный центр", "Населённый пункт : ", "Улица : ", "Дом : ", "Корпус : ", "Подъезд : ", "Этаж : ", "Квартира : "};
        string[] numClass = { " ", "5", "6", "7", "8", "9", "10", "11" };
        string[] bclass = { " ", "А", "Б", "В", "Г", "Д", "Е", "Ж" };
        string[] regions = { " ", "Брест", "Брестская область", "Витебск", "Витебская область", "Гомель", "Гомельская область", "Гродно", "Гродненская область", "Минск", "Минская область", "Могилёв", "Могилёвская область" };
        string[] brestRegion = { " ", "Брест", "Барановичи", "Берёза", "Ганцевичи", "Дрогичин", "Жабинка", "Иваново", "Ивацевичи", "Каменец", "Кобрин", "Лунинец", "Ляховичи", "Малорита", "Пинск", "Пружаны", "Столин", "Барановичский", "Берёзовский", "Брестский", "Ганцевичский", "Дрогичинский", "Жабинковский", "Ивановский", "Ивацевичский", "Каменецкий", "Кобринский", "Лунинецкий", "Ляховичский", "Малоритский", "Пинский", "Пружанский", "Столинский" };
        string[] vitebskRegion = { " ", "Бешенковичи", "Браслав", "Верхнедвинск", "Витебск", "Глубокое", "Городок", "Докшицы", "Дубровно", "Лепель", "Лиозно", "Миоры", "Орша", "Полоцк", "Новополоцк", "Поставы", "Россоны", "Сенно", "Толочин", "Ушачи", "Чашники", "Шарковщина", "Шумилино", "Бешенковичский", "Браславский", "Верхнедвинский", "Витебский", "Глубокский", "Городокский", "Докшицкий", "Дубровенский", "Лепельский", "Лиозненский", "Миорский", "Оршанский", "Полоцкий", "Поставский", "Россонский", "Сенненский", "Толочинский", "Ушачский", "Чашникский", "Шарковщинский", "Шумилинский" };
        string[] gomelRegion = { " ", "Брагин", "Буда-Кошелёво", "Ветка", "Гомель", "Добруш", "Ельск", "Житковичи", "Жлобин", "Калинковичи", "Корма", "Лельчицы", "Лоев", "Мозырь", "Наровля", "Октябрьский", "Петриков", "Речица", "Рогачёв", "Светлогорск", "Хойники", "Чечерск", "Брагинский", "Буда-Кошелёвский", "Ветковский", "Гомельский", "Добрушский", "Ельский", "Житковичский", "Жлобинский", "Калинковичский", "Кормянский", "Лельчицкий", "Лоевский", "Мозырский", "Наровлянский", "Октябрьский", "Петриковский", "Речицкий", "Рогачёвский", "Светлогорский", "Хойникский", "Чечерский" };
        string[] grodnoRegion = { " ", "Берестовица", "Волковыск", "Вороново", "Гродно", "Дятлово", "Зельва", "Ивье", "Кореличи", "Лида", "Мосты", "Новогрудок", "Островец", "Ошмяны", "Свислочь", "Слоним", "Сморгонь", "Щучин", "Берестовицкий", "Волковысский", "Вороновский", "Гродненский", "Дятловский", "Зельвенский", "Ивьевский", "Кореличский", "Лидский", "Мостовский", "Новогрудский", "Островецкий", "Ошмянский", "Свислочский", "Слонимский", "Сморгонский", "Щучинский"};
        string[] minskRegion = { " ", "Березино", "Борисов", "Вилейка", "Воложин", "Дзержинск", "Жодино", "Заславль", "Клецк", "Копыль", "Крупки", "Логойск", "Любань", "Марьина Горка", "Молодечно", "Мядель", "Несвиж", "Слуцк", "Смолевичи", "Солигорск", "Старые Дороги", "Столбцы", "Узда", "Фаниполь", "Червень", "Березинский", "Борисовский", "Вилейский", "Воложинский", "Дзержинский", "Клецкий", "Копыльский", "Крупский", "Логойский", "Любанский", "Минский", "Молодечненский", "Мядельский", "Несвижский", "Пуховичский", "Слуцкий", "Смолевичский", "Солигорский", "Стародорожский", "Столбцовский", "Узденский", "Червенский", "минск" };
        string[] mogilevRegion = { " ", "Белыничи", "Бобруйск", "Быхов", "Глуск", "Горки", "Дрибин", "Кировск", "Климовичи", "Кличев", "Краснополье", "Кричев", "Круглое", "Костюковичи", "Могилёв", "Мстиславль", "Осиповичи", "Славгород", "Хотимск", "Чаусы", "Чериков", "Шклов", "Белыничский", "Бобруйский", "Быховский", "Глусский", "Горецкий", "Дрибинский", "Кировский", "Климовичский", "Кличевский", "Краснопольский", "Кричевский", "Круглянский", "Костюковичский", "Могилёвский", "Мстиславский", "Осиповичский", "Славгородский", "Хотимский", "Чаусский", "Чериковский", "Шкловский" }; 
        public AIForm()
        {
            InitializeComponent();
            count = counter;
            additionalInf = bufData;
            this.dataGridView1.RowCount = 29;
            for (k = 0; k < 29; k++) dataGridView1.Rows[k].HeaderCell.Value = headerColumn[k];
            for (k = 0; k < 29; k++) dataGridView1.Rows[k].Cells[0].Value = additionalInf[count, k];
            DataGridViewComboBoxCell r = new DataGridViewComboBoxCell();
            r.Items.AddRange(numClass);
            r.Value = additionalInf[count, 0];
            dataGridView1.Rows[0].Cells[0] = r;
            r = new DataGridViewComboBoxCell();
            r.Items.AddRange(bclass);
            r.Value = additionalInf[count, 1];
            dataGridView1.Rows[1].Cells[0] = r;
            r = new DataGridViewComboBoxCell();
            r.Items.AddRange(regions);
            r.Value = additionalInf[count, 15];
            dataGridView1.Rows[15].Cells[0] = r;
            r = new DataGridViewComboBoxCell();
            if (additionalInf[count, 20] == regions[0]) r.Items.Add(" ");
            if (additionalInf[count, 15] == regions[2]) r.Items.AddRange(brestRegion);
            if (additionalInf[count, 15] == regions[4]) r.Items.AddRange(vitebskRegion);
            if (additionalInf[count, 15] == regions[6]) r.Items.AddRange(gomelRegion);
            if (additionalInf[count, 15] == regions[8]) r.Items.AddRange(grodnoRegion);
            if (additionalInf[count, 15] == regions[10]) r.Items.AddRange(minskRegion);
            if (additionalInf[count, 15] == regions[12]) r.Items.AddRange(mogilevRegion);
            r.Value = additionalInf[count, 16];
            dataGridView1.Rows[16].Cells[0] = r;
            r = new DataGridViewComboBoxCell();
            r.Items.AddRange(regions);
            r.Value = additionalInf[count, 20];
            dataGridView1.Rows[20].Cells[0] = r;
            r = new DataGridViewComboBoxCell();
            if (additionalInf[count, 20] == regions[0]) r.Items.Add(" ");
            if (additionalInf[count, 20] == regions[2]) r.Items.AddRange(brestRegion);
            if (additionalInf[count, 20] == regions[4]) r.Items.AddRange(vitebskRegion);
            if (additionalInf[count, 20] == regions[6]) r.Items.AddRange(gomelRegion);
            if (additionalInf[count, 20] == regions[8]) r.Items.AddRange(grodnoRegion);
            if (additionalInf[count, 20] == regions[10]) r.Items.AddRange(minskRegion);
            if (additionalInf[count, 20] == regions[12]) r.Items.AddRange(mogilevRegion);
            r.Value = additionalInf[count, 21];
            dataGridView1.Rows[21].Cells[0] = r;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            bool boole = true;
            for (k = 0; k < 29; k++)
                if (Convert.ToString(dataGridView1.Rows[k].Cells[0].Value) == "")
                    boole = false;
                else continue;
            if (boole == false)
                MessageBox.Show("Введите данные");
            else
            {
                for (k = 0; k < 29; k++) additionalInf[count, k] = Convert.ToString(dataGridView1.Rows[k].Cells[0].Value);
                StreamWriter fileForWriter = new StreamWriter("AddInformation.txt");
                for (i = 0; i < 10; i++)
                {
                    string dataRow = "";
                    for (k = 0; k < 29; k++) dataRow = dataRow + additionalInf[i, k] + '|';
                    fileForWriter.WriteLine(dataRow);
                }
                fileForWriter.Close();
                MessageBox.Show("Сохранение прошло успешно!");
            }
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 16)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewComboBoxCell r1 = new DataGridViewComboBoxCell();
                    if (Convert.ToString(dataGridView1.Rows[15].Cells[0].Value) == regions[0]) { r1.Items.Add(regions[0]); r1.Value = regions[0]; dataGridView1.Rows[16].Cells[0] = r1; dataGridView1.Rows[17].Cells[0].Value = " "; }
                    if (Convert.ToString(dataGridView1.Rows[15].Cells[0].Value) == regions[1]) { r1.Items.Add(regions[1]); r1.Value = regions[1]; dataGridView1.Rows[16].Cells[0] = r1; dataGridView1.Rows[17].Cells[0].Value = "г. " + regions[1]; }
                    if (Convert.ToString(dataGridView1.Rows[15].Cells[0].Value) == regions[2]) { r1.Items.AddRange(brestRegion); r1.Value = " "; dataGridView1.Rows[16].Cells[0] = r1; }
                    if (Convert.ToString(dataGridView1.Rows[15].Cells[0].Value) == regions[3]) { r1.Items.Add(regions[3]); r1.Value = regions[3]; dataGridView1.Rows[16].Cells[0] = r1; dataGridView1.Rows[17].Cells[0].Value = "г. " + regions[3]; }
                    if (Convert.ToString(dataGridView1.Rows[15].Cells[0].Value) == regions[4]) { r1.Items.AddRange(vitebskRegion); r1.Value = " "; dataGridView1.Rows[16].Cells[0] = r1; }
                    if (Convert.ToString(dataGridView1.Rows[15].Cells[0].Value) == regions[5]) { r1.Items.Add(regions[5]); r1.Value = regions[5]; dataGridView1.Rows[16].Cells[0] = r1; dataGridView1.Rows[17].Cells[0].Value = "г. " + regions[5]; }
                    if (Convert.ToString(dataGridView1.Rows[15].Cells[0].Value) == regions[6]) { r1.Items.AddRange(gomelRegion); r1.Value = " "; dataGridView1.Rows[16].Cells[0] = r1; }
                    if (Convert.ToString(dataGridView1.Rows[15].Cells[0].Value) == regions[7]) { r1.Items.Add(regions[7]); r1.Value = regions[7]; dataGridView1.Rows[16].Cells[0] = r1; dataGridView1.Rows[17].Cells[0].Value = "г. " + regions[7]; }
                    if (Convert.ToString(dataGridView1.Rows[15].Cells[0].Value) == regions[8]) { r1.Items.AddRange(grodnoRegion); r1.Value = " "; dataGridView1.Rows[16].Cells[0] = r1; }
                    if (Convert.ToString(dataGridView1.Rows[15].Cells[0].Value) == regions[9]) { r1.Items.Add(regions[9]); r1.Value = regions[9]; dataGridView1.Rows[16].Cells[0] = r1; dataGridView1.Rows[17].Cells[0].Value = "г. " + regions[7]; }
                    if (Convert.ToString(dataGridView1.Rows[15].Cells[0].Value) == regions[10]) { r1.Items.AddRange(minskRegion); r1.Value = " "; dataGridView1.Rows[16].Cells[0] = r1; }
                    if (Convert.ToString(dataGridView1.Rows[15].Cells[0].Value) == regions[11]) { r1.Items.Add(regions[11]); r1.Value = regions[11]; dataGridView1.Rows[16].Cells[0] = r1; dataGridView1.Rows[17].Cells[0].Value = "г. " + regions[11]; }
                    if (Convert.ToString(dataGridView1.Rows[15].Cells[0].Value) == regions[12]) { r1.Items.AddRange(mogilevRegion); r1.Value = " "; dataGridView1.Rows[16].Cells[0] = r1; }
                }
            }
        }
    }
}