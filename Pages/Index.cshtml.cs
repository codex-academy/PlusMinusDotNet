using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlusMinus.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    ICounter _counter;

    public IndexModel(ILogger<IndexModel> logger, ICounter counter)
    {
        _logger = logger;
        _counter = counter;
    }

    [BindProperty]
    public int Counter {
        get{
            return _counter.Value;
        }
    }


    [BindProperty]
    public string Action {
        get;set;
    }

    [BindProperty]
    public int Max {
        get {
            return _counter.Max;
        }

        set {
            _counter.Max = value;
        }
    }


    public void OnPost()
    {
        // Console.WriteLine("...post : " + Action);

        if(Action == "plus") {
            // Counter++;
            _counter.Plus();
        } else if (Action == "minus"){
            // Counter--;
            _counter.Minus();
        } else if (Action == "clear"){
            _counter.Clear();
        }


    }


    public void OnPostPlus() {
        _counter.Plus();
    }
}
