﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Jayden
{
    public class Pokemon : IClassModel
    {
        public int Id { get; set; }
        public int DexNumber { get; set; }
        public string Name { get; set; }
        public string Form {  get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int Total { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set;}
        public int Speed { get; set; }
        public int Generation { get; set; }


        public Pokemon(int id, int dexNumber, string name, string form, string type1, string type2, int total, int hP, int attack, int defense, int specialAttack, int specialDefense, int speed, int generation)
        {
            this.Id = id;
            this.DexNumber = dexNumber;
            this.Name = name;
            this.Form = form;
            this.Type1 = type1;
            this.Type2 = type2;
            this.Total = total;
            this.HP = hP;
            this.Attack = attack;
            this.Defense = defense;
            this.SpecialAttack = specialAttack;
            this.SpecialDefense = specialDefense;
            this.Speed = speed;
            this.Generation = generation;
        }

        public Pokemon() { }

        public override string ToString()
        {
            string msg = "";
            msg += $"{Id}, {DexNumber}, {Name}, {Form}, {Type1}, {Type2}, {Total}, {HP}, {Attack}, {Defense}, {SpecialAttack}, {SpecialDefense}, {Speed}, {Generation}.";
            return msg;
        }
    }
}
