﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGItems
{
    /*
     * This class represents a Stat.
     * It requires a name and a formula.
     * The is assigned a number based on the formula and multiplier, initialized when first called.
     */
    public class Stat
    {
        public string name { get; private set; }
        public StatFormula formula { get; private set; }
        private int amount { get; set; }
        private bool evaluated = false;

        public Stat(string Name, StatFormula Formula)
        {
            name = Name;
            formula = Formula;
        }

        public Stat(Stat s)
        {
            name = s.name;
            formula = s.formula;
        }

        public int getValue(int mult, int itemlevel)
        {
            if (!evaluated)
            {
                amount = formula.getRandomAmount(itemlevel) * mult;
                evaluated = true;
            }

            return amount;
        }

        public int getValue(Item item)
        {
            if (!evaluated)
            {
                amount = formula.getRandomAmount(item.itemLevel) * item.qualityMult;
                evaluated = true;
            }

            return amount;
        }
    }
}
