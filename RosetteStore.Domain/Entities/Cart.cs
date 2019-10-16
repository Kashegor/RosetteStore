using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosetteStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Rosette rosette, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Rosette.RosetteId == rosette.RosetteId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Rosette = rosette,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Rosette rosette)
        {
            lineCollection.RemoveAll(l => l.Rosette.RosetteId == rosette.RosetteId);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Rosette.Price * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
    public class CartLine
    {
        public Rosette Rosette { get; set; }
        public int Quantity { get; set; }
    }
}
