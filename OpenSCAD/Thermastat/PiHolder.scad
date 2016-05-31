$fn=1000;
//$fn=20;

module driverPole()
{
    cylinder(d=5.25,h=7);
}

module driverHole()
{
    cylinder(d=2.4,h=7);
}

difference()
{
    union()
    {
        cube([85.15,56.25,3]);
        translate([3.25,3.25,0]) driverPole();
        translate([61.25,3.25,0]) driverPole();
        translate([3.25,53,0]) driverPole();
        translate([61.25,53,0]) driverPole();
    }
    translate([3.25,3.25,0]) driverHole();
    translate([61.25,3.25,0]) driverHole();
    translate([3.25,53,0]) driverHole();
    translate([61.25,53,0]) driverHole();
}