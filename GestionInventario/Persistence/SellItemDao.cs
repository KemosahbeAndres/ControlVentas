﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario.Persistence
{
    class SellItemDao : Dao<Item_Venta>
    {
        public override List<Item_Venta> All()
        {
            return ctx.Item_Venta.OrderBy(x => x.id).ToList();
        }

        public override void Delete(int id)
        {
            if (!Exists(id)) return;
            var e = Get(id);
            ctx.Item_Venta.DeleteOnSubmit(e);
            ctx.SubmitChanges();
        }

        public override Item_Venta Get(int id)
        {
            return ctx.Item_Venta.SingleOrDefault(x => x.id == id);
        }

        public override void Insert(Item_Venta item)
        {
            if (!Exists(item.id))
            {
                Item_Venta e = new Item_Venta();
                e.id_producto = item.id_producto;
                e.id_venta = item.id_venta;
                ctx.Item_Venta.InsertOnSubmit(e);
                ctx.SubmitChanges();
            }
        }

        public override void Modify(Item_Venta item)
        {
            if (Exists(item.id))
            {
                Item_Venta e = Get(item.id);
                e.id_producto = item.id_producto;
                e.id_venta = item.id_venta;
                ctx.SubmitChanges();
            }
        }

        public override List<Item_Venta> Take(int index = 0, int count = 20)
        {
            return ctx.Item_Venta.Skip(index).Take(count).ToList();
        }
    }
}
