using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/on", () => HdmiOn());
app.MapGet("/off", () => HdmiOff());

app.Run();

string HdmiOn() {
    SetDisplayPowerState(true);
    return "OK, on";
}

string HdmiOff() {
    SetDisplayPowerState(false);
    return "OK, off";
}

void SetDisplayPowerState(bool powerOn)
{

    var state = powerOn ? "1" : "0";
    
    ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "/usr/bin/vcgencmd", Arguments = $"display_power {state}" }; 
    Process proc = new Process() { StartInfo = startInfo, };
    proc.Start();
}