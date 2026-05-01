using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using WebApp.Client.Services;

//template https://apalfrey.github.io/select2-bootstrap-5-theme/examples/single-select/

namespace WebApp.Client.Components;

public partial class _SelectSearchList<TValue> : InputSelect<TValue>, IAsyncDisposable
{
    bool _IsDisabled = false;
    string pathSelectCustomLibrary = "./customjs/dropdown-select2.js";

    [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();
    [Parameter] public string Css { get; set; }
    [Parameter] public Func<TValue, int> SelectorId { get; set; }
    [Parameter] public Func<TValue, string> SelectorText { get; set; }
    [Parameter] public bool ShowDefaultOption { get; set; } = false;
    [Parameter] public List<TValue> DataSource { get; set; }
    [Parameter] public EventCallback<string> EventDropdown { get; set; }
    [Parameter] public bool IsDisabled
    {
        get { return _IsDisabled; }
        set
        {
            _IsDisabled = value;
            StateHasChanged();
        }
    }

    public string Disabled { get; set; }


    [Inject] private IJSRuntime Js { get; set; }
    private IJSObjectReference _jsRef;
    public DotNetObjectReference<_SelectSearchList<TValue>> DotNetRef;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        DotNetRef = DotNetObjectReference.Create(this);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _jsRef = await Js.InvokeAsync<IJSObjectReference>("import", pathSelectCustomLibrary);
            await Js.InvokeVoidAsync("select2Component.init", Id);
            await Js.InvokeVoidAsync("select2Component.onChange", Id, DotNetRef, "Change_Invokable");
        }
        await base.OnAfterRenderAsync(firstRender);
    }


    [JSInvokable("Change_Invokable")]
    public void Change(string value)
    {
        if (value == "null") value = null;
        if (typeof(TValue) == typeof(string))
        {
            CurrentValue = (TValue)(object)value!;

        }
        else if (typeof(TValue) == typeof(int))
        {
            int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue);
            CurrentValue = (TValue)(object)parsedValue;
        }
        else if (typeof(TValue) != typeof(int))
        {
            if (value == null)
            {
                CurrentValue = default(TValue);
            }
            else
            {
                int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue);

                TValue objectValue = DataSource.First(x => SelectorId(x) == parsedValue);

                CurrentValue = objectValue; //(TValue)(object)parsedValue;
            }
        }
        else
            throw new Exception("only string, int or TValue types are accepted");


        EventDropdown.InvokeAsync(value);
    }


    //protected override string FormatValueAsString(TValue? value)
    //{
    //    if (value == null)
    //    {
    //        //IsValidInput = false;
    //        return string.Empty;
    //    }

    //    //IsValidInput = true;
    //    return SelectorId(value).ToString();
    //}

    //protected override bool TryParseValueFromString(string? value, out TValue result, out string validationErrorMessage)
    //{
    //    result = DataSource.First(x => SelectorId(x) == int.Parse(value));
    //    validationErrorMessage = string.Empty;
    //    return true;
    //}


    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (_jsRef != null) await _jsRef.DisposeAsync();
    }

    public async ValueTask DisposeAsync()
    {
        try
        {
            await DisposeAsyncCore();
            GC.SuppressFinalize(this);
        }
        catch (JSDisconnectedException e)
        {
            Console.WriteLine(e.ToString());
            // Ignore
        }
    }

}