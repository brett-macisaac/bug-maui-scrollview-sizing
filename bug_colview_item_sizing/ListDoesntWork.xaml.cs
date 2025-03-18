using System.Collections.ObjectModel;
using System.Windows.Input;

namespace bug_colview_item_sizing;

public partial class ListDoesntWork : ContentPage
{
    private Dictionary<string, List<string>> fLists;
    protected Dictionary<string, List<string>> Lists
    {
        get { return fLists; }
        set { fLists = value; OnPropertyChanged(nameof(Lists)); }
    }

    private string[] fListNames;
    public string[] ListNames
    {
        get { return fListNames; }
        set { fListNames = value; OnPropertyChanged(nameof(ListNames)); }
    }

    private List<string> fList;
    public List<string> List
    {
        get { return fList; }
        set { fList = value; OnPropertyChanged(nameof(List)); }
    }

    private string fSelectedListName;
    public string SelectedListName
    {
        get { return fSelectedListName; }
        set { fSelectedListName = value; OnPropertyChanged(nameof(SelectedListName)); }
    }

    private bool fShowList;
    public bool ShowList
    {
        get { return fShowList; }
        set { fShowList = value; OnPropertyChanged(nameof(ShowList)); }
    }

    public ListDoesntWork()
    {
        Lists = new Dictionary<string, List<string>>()
        {
            {
                "Numbers",
                new List<string>()
                {
                    "1111111111",
                    "2222222222",
                    "3333333333",
                    "4444444444",
                    "5555555555",
                    "6666666666",
                    "7777777777",
                    "8888888888",
                    "9999999999",
                    "-8888888888",
                    "-7777777777",
                    "-6666666666",
                    "-5555555555",
                    "-4444444444",
                    "-3333333333",
                    "-2222222222",
                    "-1111111111",
                }
            },
            {
                "Letters",
                new List<string>
                {
                    "aaaaaaaaaa",
                    "bbbbbbbbbb",
                    "cccccccccc",
                    "dddddddddd",
                }
            }
        };

        InitializeComponent();

        Initialise();
    }

    public void Initialise()
    {
        if (Lists == null || Lists.Count == 0)
            return;

        ListNames = Lists.Keys.ToArray();

        SelectedListName = ListNames[0];

        ShowList = true;
    }

    public ICommand SwitchTableCommand => new Command(
        () =>
        {
            if (string.IsNullOrWhiteSpace(SelectedListName) || ListNames == null || !Lists.ContainsKey(SelectedListName))
                return;

            List = Lists[SelectedListName];
        }
    );

    public ICommand CmdShowList => new Command(
        () =>
        {
            ShowList = !ShowList;
        }
    );

    public ICommand CmdHideList => new Command(
        () =>
        {
            ShowList = false;
        }
    );


    public ICommand CmdToggleShowList => new Command(
        () =>
        {
            ShowList = !ShowList;
        }
    );
}