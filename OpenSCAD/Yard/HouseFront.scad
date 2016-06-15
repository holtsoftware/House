use <HouseWindows.scad>;
use <SolarRoof.scad>;

//$fn=20;
$fn=300;


module SoilMoisture()
{
    difference()
    {
        union()
        {
            cube([24,61.5,4]);
            color("blue")translate([5.5,45,-2])cube([11.5,16.5,2]);
        }
            translate([3.2,58,0]) cylinder(d=2.5,h=5);
            translate([20.5,58,0]) cylinder(d=2.5,h=5);
        translate([7.875,0,0]) cube([6.75,43,4]);
    }
}

module doorWindowUpdate()
{
    translate([0,23,3.5]) rotate([180,0,0]) doorWindow();
    translate([0,0,3]) cube([23,23,5]);
}

module windowUpdate()
{
    translate([0,23,3.5]) rotate([180,0,0]) window();
    translate([0,0,3]) cube([38,23,5]);
}

module main()
{
difference()
{
    union()
    {
        cube([90,120,5]);
        translate([5,5,5]) cube([79,70,2]);
    }
    translate([35,-42,3]) SoilMoisture();
    translate([55,45,0])doorWindowUpdate();
    translate([10,45,0]) windowUpdate();
    translate([2.5,10,0]) cylinder(d=3,h=8);
    translate([87,10,0]) cylinder(d=3,h=8);
    translate([2.5,60,0]) cylinder(d=3,h=8);
    translate([87,60,0]) cylinder(d=3,h=8);
}
}

difference()
{
    translate([10,95.3,0]) rotate([90,0,-90]) main();
translate([0,0,65]) roof();

color("blue") translate([0,0,71]) rotate([45,0,0]) cube([135,100,35]);
color("blue") translate([0,36,133]) rotate([-45,0,0]) cube([135,100,35]);
}

//SoilMoisture();





