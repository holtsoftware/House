$fn=1000;

module driverPole()
{
    cylinder(d=5.25,h=12);
}

module driverHole()
{
    cylinder(d=2.4,h=12);
}

difference()
{
    union()
    {
        cube([65.05,56.31,3]);
        translate([3.25,3.25,0]) driverPole();
        translate([61.8,3.25,0]) driverPole();
        translate([3.25,53.06,0]) driverPole();
        translate([61.8,53.06,0]) driverPole();
    }
    translate([3.25,3.25,0]) driverHole();
    translate([61.8,3.25,0]) driverHole();
    translate([3.25,53.06,0]) driverHole();
    translate([61.8,53.06,0]) driverHole();
}