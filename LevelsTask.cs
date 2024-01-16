using System;
using System.Collections.Generic;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
              (size, v) => new Vector(0, -0.9), standardPhysics); ;

            //3 lvl
            yield return new Level("Up",
               new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
               new Vector(700, 500),

               (size, v) =>  gravityUp(size, v), standardPhysics);
            //4 lvl
            yield return new Level("WhiteHole",
               new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
               new Vector(600, 200),
               (size, v) => gravityWhiteHole(size, v, new Vector(600, 200)), standardPhysics);
            //5 lvl
            yield return new Level("BlackHole",
               new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
            new Vector(600, 200),
               (size, v) => gravityBlackHole(size, v, new Vector(400, 350)), standardPhysics);
            //6 lvl
            yield return new Level("BlackAndWhite",
               new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
               new Vector(600, 200),
               (size, v) => gravityBlackAndWhite(size, v, new Vector(600, 200), new Vector(400, 350)), standardPhysics);

        }
        private static Vector gravityUp(Size size, Vector v)
        {
            double bottomDistance = size.Height - v.Y;
            double gravityUp = 300.0 / (bottomDistance + 300.0);
            Vector result = new Vector(0,gravityUp);
            return result;
        }
        private static Vector gravityWhiteHole(Size size, Vector v, Vector target)
        {
            double distance = Math.Sqrt(Math.Pow(v.X - target.X, 2) + Math.Pow(v.Y - target.Y, 2));
            double gravityforce = 140.0 * distance / (Math.Pow(distance, 2) + 1.0);
            Vector gravity = new Vector(v.X - target.X, v.Y - target.Y);
            gravity = gravity.Normalize();
            Vector result = gravity * gravityforce; 
            return result;  
        }
        private static Vector gravityBlackHole(Size size, Vector v, Vector target)
        {
            double distance = Math.Sqrt(Math.Pow(v.X - target.X, 2) + Math.Pow(v.Y - target.Y, 2));
            double gravityForce = 300.0 * distance / (Math.Pow(distance, 2) + 1.0);
            Vector gravity = new Vector((target.X - v.X), (target.Y - v.Y));
            gravity = gravity.Normalize();
            Vector result = gravity * gravityForce;
            return result;
        }
        private static Vector gravityBlackAndWhite(Size size, Vector v, Vector target,Vector anomale)
        {
            double distanceWhite = Math.Sqrt(Math.Pow(v.X - target.X, 2) + Math.Pow(v.Y - target.Y, 2));
            double gravityforceWhite = 140.0 * distanceWhite / (Math.Pow(distanceWhite, 2) + 1.0);
            Vector gravityWhite = new Vector(v.X - target.X, v.Y - target.Y);
            gravityWhite = gravityWhite.Normalize();
            Vector resultWhite = gravityWhite * gravityforceWhite;
            
            double distanceBlack = Math.Sqrt(Math.Pow(v.X - anomale.X, 2) + Math.Pow(v.Y - anomale.Y, 2));
            double gravityForceBlack = 300.0 * distanceBlack / (Math.Pow(distanceBlack, 2) + 1.0);
            Vector gravityBlack = new Vector((anomale.X - v.X), (anomale.Y - v.Y));
            gravityBlack = gravityBlack.Normalize();
            Vector resultBlack = gravityBlack * gravityForceBlack;

            Vector allResult = resultWhite + resultBlack/2;
            return allResult;
        }
    }
}