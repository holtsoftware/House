$fn=300;
//$fn=20;

module driverPole()
{
    cylinder(d=4,h=7);
}

module driverHole()
{
    cylinder(d=2.5,h=7);
}

difference()
{
    union()
    {
        cube([40.6,33.3,3]);
        translate([2.5,2.5,0]) driverPole();
        translate([2.5,28.2,0]) driverPole();
        translate([38.1,2.5,0]) driverPole();
        translate([38.1,28.2,0]) driverPole();
    }
    translate([2.5,2.5]) driverHole();
    translate([2.5,28.2,0]) driverHole();
    translate([38.1,2.5,0]) driverHole();
    translate([38.1,28.2,0]) driverHole();
}