namespace IteratorExample
{
    public class ShapeIterator : Iterator<Shape>
    {
        private Shape[] shapes;
        public int position = -1;

        public ShapeIterator(Shape[] shape)
        {
            this.shapes  =  shape;
        }

        public bool HasNext()
        {
            int nextPosition = position + 1;
            if (nextPosition < this.shapes.Length)
                return this.shapes[nextPosition] != null;
            return false;
        }
        
        public Shape Next()
        {
            this.position++;
            return this.shapes[position];
        }
        
        public void Remove()
        {
            shapes[position] = null;
        }

    }
}