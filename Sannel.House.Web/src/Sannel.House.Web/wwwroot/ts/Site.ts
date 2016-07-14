/// <reference path="jquery.d.ts" />
/// <reference path="knockout.d.ts" />

class ServerDevice {
	Id: Number;
	Name: string;
	Description: string;
    DisplayOrder: Number;
    IsReadOnly: boolean;
}

class Device {
	Id: KnockoutObservable<Number> = ko.observable(0);
	Name: KnockoutObservable<string> = ko.observable("");
	Description: KnockoutObservable<string> = ko.observable("");
    DisplayOrder: KnockoutObservable<Number> = ko.observable(0);
    IsReadOnly: KnockoutObservable<boolean> = ko.observable(false);

	constructor(sdevice: ServerDevice = undefined) {
		if (sdevice != undefined) {
			this.Id(sdevice.Id);
			this.Name(sdevice.Name);
			this.Description(sdevice.Description);
            this.DisplayOrder(sdevice.DisplayOrder);
            this.IsReadOnly(sdevice.IsReadOnly);
		}
	}

	public AsServerDevice(): ServerDevice {
		var sd = new ServerDevice();
		sd.Id = this.Id();
		sd.Name = this.Name();
		sd.Description = this.Description();
        sd.DisplayOrder = this.DisplayOrder();
        sd.IsReadOnly = this.IsReadOnly();
		return sd;
	}
}

class DevicesViewModel {
	private _apiUrl: string;
	public Devices: KnockoutObservableArray<Device> = ko.observableArray([]);
	public CurrentDevice: KnockoutObservable<Device> = ko.observable(undefined);

	constructor() {
		this._apiUrl = "/api/Devices";
	}

	private _devicesReceived(data: ServerDevice[]) {
		for (var i = 0; i < data.length; i++) {
			this.Devices.push(new Device(data[i]));
		}
	}

	public loadDevices() {
		var me = this;
		$.ajax({
			url: me._apiUrl,
			type: 'get',
			contentType: "application/json; charset=utf-8",
			success: function (data) {
				me._devicesReceived(data);
			}
		});
	}

	public loadDevice(id: Number) {
		var me = this;
		$.ajax({
			url: me._apiUrl + "/" + id,
			type: 'get',
			contentType: "application/json; charset=utf-8",
			success: function (device: ServerDevice) {
				var found = false;
				for (var i = 0; i < me.Devices().length; i++) {
					var d = me.Devices()[i];
					if (d.Id() == device.Id) {
						me.Devices.replace(d, new Device(device));
						found = true;
						break;
					}
				}
				if (!found) {
					me.Devices.push(new Device(device));
				}
			}
		});
	}

	public AddNewDevice() {
		this.CurrentDevice(new Device());
    }

    private validateDevice(dev: Device): boolean {
        var cd = this.CurrentDevice();
        var errorMessage: string = "";
        if (cd.Name().length <= 0) {
            errorMessage = "Name is required.\n";
        }
        if (cd.Description().length <= 0) {
            errorMessage += "Description is required.\n";
        }

        if (errorMessage.length > 0) {
            alert(errorMessage);
        }

        return errorMessage.length == 0;
    }

	public SaveNewDevice() {
		var cd = this.CurrentDevice();

        if (this.validateDevice(cd)) {
            var me = this;
            me.CurrentDevice(undefined);
			$.ajax({
				url: me._apiUrl,
				type: 'post',
				contentType: "application/json; charset=utf-8",
				data: JSON.stringify(cd.AsServerDevice()),
				dataType: "json",
				success: function (id) {
                    me.loadDevice(id);
                    me.CurrentDevice(undefined);
				}
			});
		}
    }

    public EditDevice(dev: Device) {
        this.CurrentDevice(dev);
    }

    public UpdateDevice() {
        var cd = this.CurrentDevice();
        var me = this;
        if (this.validateDevice(cd)) {
            me.CurrentDevice(undefined);
            $.ajax({
                url: me._apiUrl,
                type: "PUT",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(cd.AsServerDevice()),
                dataType: "json",
                success: function () {
                    me.loadDevice(cd.Id());
                }
            });
        }
    }
}