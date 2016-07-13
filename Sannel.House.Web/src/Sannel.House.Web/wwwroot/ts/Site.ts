/// <reference path="jquery.d.ts" />
/// <reference path="knockout.d.ts" />

interface Device {
    Id: Number;
    Name: String;
    Description: String;
    DisplayOrder: Number;
}

class DevicesViewModel {
    private _apiUrl: string;
    public Devices: KnockoutObservableArray<Device> = ko.observableArray([]);

    constructor() {
        this._apiUrl = "/api/Devices";
    }

    private _devicesReceived(data: Device[]) {
        console.log(data);
        for (var i = 0; i < data.length; i++) {
            this.Devices.push(data[i]);
        }
    }

    loadDevices() {
        var me = this;
        console.log(me._apiUrl);
        $.ajax({
            url: me._apiUrl,
            type: 'get',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                me._devicesReceived(data);
            }
        });
    }
}