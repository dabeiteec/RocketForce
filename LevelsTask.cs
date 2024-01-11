using System;
using System.Collections.Generic;
using System.Drawing;

namespace func_rocket
{
	public class LevelsTask
	{
		static readonly Physics standardPhysics = new Physics();

		//public static IEnumerable<Level> CreateLevels(Size spaceSize)
        public static IEnumerable<Level> CreateLevels()
        {
			yield return new Level("Zero", 
				new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
				new Vector(600, 200), 
				(size, v) => Vector.Zero, standardPhysics);
            //TODO: ...
            yield return new Level("Heavy",
              new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
              new Vector(600, 200),
              (size, v) => new Vector(0, -0.9), standardPhysics);

            //3 lvl
            yield return new Level("Up",
               new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
               new Vector(700, 500),
               //(size, v) => new Vector(0, -0.9), standardPhysics);
               (size, v) => new Vector(0, gravityUp(size, v)), standardPhysics);
            //4 lvl
            yield return new Level("WhiteHole",
               new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
               new Vector(600, 200),
               (size, v) => new Vector( 0,gravityWhiteHole(size, v)), standardPhysics);
            //5 lvl
            yield return new Level("BlackHole",
               new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
               new Vector(600, 200),
               (size, v) => Vector.Zero, standardPhysics);
            //6 lvl
            yield return new Level("BlackAndWhite",
               new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
               new Vector(600, 200),
               (size, v) => Vector.Zero, standardPhysics);

        }
        private static double gravityUp(Size size, Vector v)
        {
            double resultGravityUp = 300.0 / (size.Height - v.Y + 300.0);
            return  resultGravityUp;
        }
        private static double gravityWhiteHole(Size size, Vector v)
        {
            double resultGraviryWhiteHoleHeigth = 0;
            return resultGraviryWhiteHoleHeigth;
        }
    }
}