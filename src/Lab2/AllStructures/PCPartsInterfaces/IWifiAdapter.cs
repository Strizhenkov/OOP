using System;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;

public interface IWifiAdapter : IUsingPowerComponent
{
    IWifiAdapter SetWifiVersion(string wifiVersion);
    IWifiAdapter SetBluetoothStatus(bool bluetoothStatus);
    IWifiAdapter SetPciE(string pciE);
    IWifiAdapter Builder(string wifiVersion, bool bluetoothStatus, string pciE, int usedPower);
}

public class WifiAdapter : IWifiAdapter
{
    private string? _wifiVersion;
    private bool _bluetoothStatus;
    private string? _pciE;

    public int UsedPower { get; private set; }

    public IWifiAdapter Builder(string wifiVersion, bool bluetoothStatus, string pciE, int usedPower)
    {
        return (IWifiAdapter)new WifiAdapter().SetWifiVersion(wifiVersion).SetBluetoothStatus(bluetoothStatus).SetPciE(pciE)
            .SetUsedPower(usedPower);
    }

    public IWifiAdapter SetWifiVersion(string wifiVersion)
    {
        _wifiVersion = wifiVersion ?? throw new ArgumentNullException(nameof(wifiVersion), $"Null wifiVersion");
        return this;
    }

    public IWifiAdapter SetBluetoothStatus(bool bluetoothStatus)
    {
        _bluetoothStatus = bluetoothStatus;
        return this;
    }

    public IWifiAdapter SetPciE(string pciE)
    {
        _pciE = pciE ?? throw new ArgumentNullException(nameof(pciE), $"Null pciE");
        return this;
    }

    public IUsingPowerComponent SetUsedPower(int usedPower)
    {
        UsedPower = usedPower;
        return this;
    }
}