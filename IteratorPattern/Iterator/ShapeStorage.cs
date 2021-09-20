using System;

namespace IteratorExample
{
    class ShapeStorage
    {
        private Shape[] shapes = new Shape[10];
        private int index = 0;
        
        public void AddShape(string shape)
        {
            shapes[index] = new Shape(index, shape);
            index++;
        }

        public Shape[] GetShapes()
        {
            return shapes;
        }
    }
}