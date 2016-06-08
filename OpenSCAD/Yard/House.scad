include <SolarRoof.scad>

difference()
{
union()
{
translate([0,0,65]) roof();
translate([0,5,0]) cube([135,5,75]);
translate([0,90,0]) cube([135,5,75]);
translate([0,5,0]) cube([135,85,5]);
translate([0,5,0]) cube([5,90,121.5]);
}

color("blue") translate([0,0,72.1]) rotate([45,0,0]) cube([135,100,35]);
color("blue") translate([0,36,135.1]) rotate([-45,0,0]) cube([135,100,35]);
}