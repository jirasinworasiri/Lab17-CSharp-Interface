using System;

interface IRemoteControl
{
    void TurnOn();
    void TurnOff();
    void ChannelUp();
    void ChannelDown();
}

abstract class PowerAppliance
{
    public bool PowerStatus { get; set; } = false; // ตั้งค่าเริ่มต้นเป็นปิด
    public int Wattage { get; set; }
}

abstract class Television : PowerAppliance, IRemoteControl
{
    public int Channel { get; set; } = 1;

    public virtual void TurnOn() { Console.WriteLine("TV Turn on"); PowerStatus = true; }
    public virtual void TurnOff() { Console.WriteLine("TV Turn off"); PowerStatus = false; }
    public virtual void ChannelUp() { Console.WriteLine($"TV Channel up: {++Channel}"); }
    public virtual void ChannelDown() { Console.WriteLine($"TV Channel down: {--Channel}"); }
}

class SonyTV : Television
{
    public override void TurnOn() { Console.WriteLine("Sony TV Turn on"); PowerStatus = true; }
    public override void TurnOff() { Console.WriteLine("Sony TV Turn off"); PowerStatus = false; }
    public override void ChannelUp() { Console.WriteLine($"Sony TV Channel up: {++Channel}"); }
    public override void ChannelDown() { Console.WriteLine($"Sony TV Channel down: {--Channel}"); }
}

class Lamp : PowerAppliance
{
    public void TurnOn() { Console.WriteLine("Lamp Turn on"); PowerStatus = true; }
    public void TurnOff() { Console.WriteLine("Lamp Turn off"); PowerStatus = false; }
}

class Program
{
    static void Main()
    {
        Television myTV = new SonyTV();
        myTV.Wattage = 100;
        myTV.TurnOn();
        myTV.ChannelUp();
        myTV.ChannelDown();
        myTV.TurnOff();

        Lamp myLamp = new Lamp();
        myLamp.Wattage = 50;
        myLamp.TurnOn();
        myLamp.TurnOff();
    }
}
