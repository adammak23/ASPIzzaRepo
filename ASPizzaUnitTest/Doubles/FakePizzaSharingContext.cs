﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPizza.Models;

namespace ASPizzaUnitTest.Doubles
{
    class FakePizzaSharingContext: IPizzaSharingContext
    {
        SetMap _map = new SetMap();

        public IQueryable<Pizza> Pizzas
        {
            get { return _map.Get<Pizza>().AsQueryable(); }
            set { _map.Use<Pizza>(value); }
        }

        public IQueryable<Dodatek> Dodatki
        {
            get { return _map.Get<Dodatek>().AsQueryable(); }
            set { _map.Use<Dodatek>(value); }
        }

        public bool ChangesSaved { get; set; }

        public int SaveChanges()
        {
            ChangesSaved = true;
            return 0;
        }

        public T Add<T>(T entity) where T : class
        {
            _map.Get<T>().Add(entity);
            return entity;
        }

        public T Delete<T>(T entity) where T : class
        {
            _map.Get<T>().Remove(entity);
            return entity;
        }

        public Pizza FindPizzaById(int id)
        {
            Pizza item = (from p in this.Pizzas
                           where p.Id == id
                           select p).FirstOrDefault();
            return item;
        }

        public Dodatek FindDodatekById(int id)
        {
            Dodatek dodatek = (from a in this.Dodatki
                           where a.Id == id
                           select a).FirstOrDefault();
            return dodatek;
        }

        public IQueryable<Pizza> PricelessPizzass()
        {
            IQueryable<Pizza> pizzas = Pizzas.Where(p => p.Price == 0);
            return pizzas;
        }

        class SetMap : KeyedCollection<Type, object>
        {
            public HashSet<T> Use<T>(IEnumerable<T> sourceData)
            {
                var set = new HashSet<T>(sourceData);
                if (Contains(typeof(T)))
                {
                    Remove(typeof(T));
                }
                Add(set);
                return set;
            }

            public HashSet<T> Get<T>()
            {
                return (HashSet<T>)this[typeof(T)];
            }

            protected override Type GetKeyForItem(object item)
            {
                return item.GetType().GetGenericArguments().Single();
            }
        }
    }
}
