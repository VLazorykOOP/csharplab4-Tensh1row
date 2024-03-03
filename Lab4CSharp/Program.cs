//Exercise 1
using System; 

  

class DRomb 

{ 

    // Поля 

    protected int d1; // Перша діагональ 

    protected int d2; // Друга діагональ 

    protected int color; // Колір ромба 

  

    // Конструктор 

    public DRomb(int diagonal1, int diagonal2, int color) 

    { 

        this.d1 = diagonal1; 

        this.d2 = diagonal2; 

        this.color = color; 

    } 

  

    // Властивості 

    public int Diagonal1 

    { 

        get { return d1; } 

        set { d1 = value; } 

    } 

  

    public int Diagonal2 

    { 

        get { return d2; } 

        set { d2 = value; } 

    } 

  

    public int Color 

    { 

        get { return color; } 

    } 

  

    // Індексатор 

    public int this[int index] 

    { 

        get 

        { 

            switch (index) 

            { 

                case 0: 

                    return d1; 

                case 1: 

                    return d2; 

                case 2: 

                    return color; 

                default: 

                    throw new IndexOutOfRangeException("Index out of range."); 

            } 

        } 

    } 

  

    // Методи 

    public void PrintDimensions() 

    { 

        Console.WriteLine($"Перша діагональ: {d1}"); 

        Console.WriteLine($"Друга діагональ: {d2}"); 

    } 

  

    public double CalculatePerimeter() 

    { 

        return 2 * (d1 + d2); 

    } 

  

    public double CalculateArea() 

    { 

        return (d1 * d2) / 2.0; 

    } 

  

    public bool IsSquare() 

    { 

        return d1 == d2; 

    } 

  

    // Перевантаження операторів 

    public static bool operator true(DRomb r) 

    { 

        return r.IsSquare(); 

    } 

  

    public static bool operator false(DRomb r) 

    { 

        return !r.IsSquare(); 

    } 

  

    public static DRomb operator ++(DRomb r) 

    { 

        r.d1++; 

        r.d2++; 

        return r; 

    } 

  

    public static DRomb operator --(DRomb r) 

    { 

        r.d1--; 

        r.d2--; 

        return r; 

    } 

  

    public static DRomb operator +(DRomb r, int scalar) 

    { 

        r.d1 += scalar; 

        r.d2 += scalar; 

        return r; 

    } 

  

    public static explicit operator string(DRomb r) 

    { 

        return $"Діагональ 1: {r.d1}, Діагональ 2: {r.d2}, Колір: {r.color}"; 

    } 

  

    public static explicit operator DRomb(string description) 

    { 

        string[] parts = description.Split(','); 

        if (parts.Length != 3) 

            throw new ArgumentException("Invalid string format."); 

         

        int d1 = int.Parse(parts[0].Split(':')[1]); 

        int d2 = int.Parse(parts[1].Split(':')[1]); 

        int color = int.Parse(parts[2].Split(':')[1]); 

  

        return new DRomb(d1, d2, color); 

    } 

} 

  

class Program 

{ 

    static void Main(string[] args) 

    { 

        // Створення ромбів із заданими параметрами 

        DRomb romb1 = new DRomb(5, 5, 1); // Квадрат 

        DRomb romb2 = new DRomb(6, 8, 2); // Звичайний ромб 

  

        // Виведення інформації про ромби 

        Console.WriteLine("Ромб 1:"); 

        romb1.PrintDimensions(); 

        Console.WriteLine($"Колір: {romb1.Color}"); 

        Console.WriteLine($"Периметр: {romb1.CalculatePerimeter()}"); 

        Console.WriteLine($"Площа: {romb1.CalculateArea()}"); 

        Console.WriteLine($"Чи є квадратом: {romb1.IsSquare()}"); 

  

        Console.WriteLine(); 

  

        Console.WriteLine("Ромб 2:"); 

        romb2.PrintDimensions(); 

        Console.WriteLine($"Колір: {romb2.Color}"); 

        Console.WriteLine($"Периметр: {romb2.CalculatePerimeter()}"); 

        Console.WriteLine($"Площа: {romb2.CalculateArea()}"); 

        Console.WriteLine($"Чи є квадратом: {romb2.IsSquare()}"); 

  

        Console.WriteLine(); 

  

        // Використання перегрузок операторів 

        Console.WriteLine("Використання перегрузок операторів:"); 

        DRomb romb3 = new DRomb(3, 3, 3); 

        Console.WriteLine($"Ромб 3 до зміни: {romb3.Diagonal1}, {romb3.Diagonal2}"); 

        romb3++; 

        Console.WriteLine($"Ромб 3 після зміни: {romb3.Diagonal1}, {romb3.Diagonal2}"); 

        romb3 += 2; 

        Console.WriteLine($"Ромб 3 після додавання скаляру: {romb3.Diagonal1}, {romb3.Diagonal2}"); 

        Console.WriteLine($"Ромб 3 чи є квадратом: {romb3.IsSquare()}"); 

  

        Console.WriteLine(); 

  

        // Перетворення типу 

        Console.WriteLine("Перетворення типу:"); 

        string rombString = (string)romb1; 

        Console.WriteLine($"Рядок, що представляє ромб 1: {rombString}"); 

        DRomb convertedRomb = (DRomb)rombString; 

        Console.WriteLine($"Перетворений ромб: {convertedRomb.Diagonal1}, {convertedRomb.Diagonal2}, {convertedRomb.Color}"); 

  

        Console.ReadLine(); 

    } 

} 

//Exercise 2
using System; 

  

class VectorULong 

{ 

    protected ulong[] IntArray; 

    protected uint size; 

    protected int codeError; 

    static uint num_vec; 

  

    public uint Size { get { return size; } } 

    public int CodeError { get { return codeError; } set { codeError = value; } } 

  

    public VectorULong() 

    { 

        size = 1; 

        IntArray = new ulong[size]; 

        codeError = 0; 

        num_vec++; 

    } 

  

    public VectorULong(uint newSize) 

    { 

        size = newSize; 

        IntArray = new ulong[size]; 

        codeError = 0; 

        num_vec++; 

    } 

  

    public VectorULong(uint newSize, ulong initValue) 

    { 

        size = newSize; 

        IntArray = new ulong[size]; 

        for (uint i = 0; i < size; i++) 

        { 

            IntArray[i] = initValue; 

        } 

        codeError = 0; 

        num_vec++; 

    } 

  

    ~VectorULong() 

    { 

        Console.WriteLine("Destructor Called"); 

    } 

  

    public void InputValues() 

    { 

        Console.WriteLine("Enter values for the vector:"); 

        for (uint i = 0; i < size; i++) 

        { 

            Console.Write("Element {0}: ", i); 

            IntArray[i] = Convert.ToUInt64(Console.ReadLine()); 

        } 

    } 

  

    public void DisplayValues() 

    { 

        Console.WriteLine("Vector elements:"); 

        for (uint i = 0; i < size; i++) 

        { 

            Console.WriteLine("Element {0}: {1}", i, IntArray[i]); 

        } 

    } 

  

    public void SetValues(ulong value) 

    { 

        for (uint i = 0; i < size; i++) 

        { 

            IntArray[i] = value; 

        } 

    } 

  

    public static uint CountVectors() 

    { 

        return num_vec; 

    } 

  

    public ulong this[uint index] 

    { 

        get 

        { 

            if (index >= size) 

            { 

                codeError = -1; 

                return 0; 

            } 

            codeError = 0; 

            return IntArray[index]; 

        } 

        set 

        { 

            if (index >= size) 

            { 

                codeError = -1; 

            } 

            else 

            { 

                IntArray[index] = value; 

                codeError = 0; 

            } 

        } 

    } 

  

    // Overloading unary operators 

    public static VectorULong operator ++(VectorULong v) 

    { 

        for (uint i = 0; i < v.size; i++) 

        { 

            v.IntArray[i]++; 

        } 

        return v; 

    } 

  

    public static VectorULong operator --(VectorULong v) 

    { 

        for (uint i = 0; i < v.size; i++) 

        { 

            v.IntArray[i]--; 

        } 

        return v; 

    } 

  

    public static bool operator true(VectorULong v) 

    { 

        foreach (ulong val in v.IntArray) 

        { 

            if (val == 0) 

                return false; 

        } 

        return true; 

    } 

  

    public static bool operator false(VectorULong v) 

    { 

        foreach (ulong val in v.IntArray) 

        { 

            if (val == 0) 

                return true; 

        } 

        return false; 

    } 

  

    public static VectorULong operator !(VectorULong v) 

    { 

        for (uint i = 0; i < v.size; i++) 

        { 

            v.IntArray[i] = (v.IntArray[i] == 0) ? 1u : 0u; 

        } 

        return v; 

    } 

  

    public static VectorULong operator ~(VectorULong v) 

    { 

        for (uint i = 0; i < v.size; i++) 

        { 

            v.IntArray[i] = ~v.IntArray[i]; 

        } 

        return v; 

    } 

  

    // Overloading binary arithmetic operators 

    public static VectorULong operator +(VectorULong v1, VectorULong v2) 

    { 

        uint maxSize = Math.Max(v1.size, v2.size); 

        VectorULong result = new VectorULong(maxSize); 

        for (uint i = 0; i < maxSize; i++) 

        { 

            result[i] = (i < v1.size ? v1[i] : 0) + (i < v2.size ? v2[i] : 0); 

        } 

        return result; 

    } 

  

    public static VectorULong operator +(VectorULong v, ulong scalar) 

    { 

        VectorULong result = new VectorULong(v.size); 

        for (uint i = 0; i < v.size; i++) 

        { 

            result[i] = v[i] + scalar; 

        } 

        return result; 

    } 

  

    public static VectorULong operator -(VectorULong v1, VectorULong v2) 

    { 

        uint maxSize = Math.Max(v1.size, v2.size); 

        VectorULong result = new VectorULong(maxSize); 

        for (uint i = 0; i < maxSize; i++) 

        { 

            result[i] = (i < v1.size ? v1[i] : 0) - (i < v2.size ? v2[i] : 0); 

        } 

        return result; 

    } 

  

    public static VectorULong operator -(VectorULong v, ulong scalar) 

    { 

        VectorULong result = new VectorULong(v.size); 

        for (uint i = 0; i < v.size; i++) 

        { 

            result[i] = v[i] - scalar; 

        } 

        return result; 

    } 

  

    public static VectorULong operator *(VectorULong v1, VectorULong v2) 

    { 

        uint maxSize = Math.Max(v1.size, v2.size); 

        VectorULong result = new VectorULong(maxSize); 

        for (uint i = 0; i < maxSize; i++) 

        { 

            result[i] = (i < v1.size ? v1[i] : 0) * (i < v2.size ? v2[i] : 0); 

        } 

        return result; 

    } 

  

    public static VectorULong operator *(VectorULong v, ulong scalar) 

    { 

        VectorULong result = new VectorULong(v.size); 

        for (uint i = 0; i < v.size; i++) 

        { 

            result[i] = v[i] * scalar; 

        } 

        return result; 

    } 

  

    public static VectorULong operator /(VectorULong v1, VectorULong v2) 

    { 

        uint maxSize = Math.Max(v1.size, v2.size); 

        VectorULong result = new VectorULong(maxSize); 

        for (uint i = 0; i < maxSize; i++) 

        { 

            result[i] = (i < v1.size ? v1[i] : 0) / (i < v2.size ? v2[i] : 1); 

        } 

        return result; 

    } 

  

    public static VectorULong operator /(VectorULong v, ulong scalar) 

    { 

        if (scalar == 0) 

        { 

            throw new DivideByZeroException(); 

        } 

        VectorULong result = new VectorULong(v.size); 

        for (uint i = 0; i < v.size; i++) 

        { 

            result[i] = v[i] / scalar; 

        } 

        return result; 

    } 

  

    public static VectorULong operator %(VectorULong v1, VectorULong v2) 

    { 

        uint maxSize = Math.Max(v1.size, v2.size); 

        VectorULong result = new VectorULong(maxSize); 

        for (uint i = 0; i < maxSize; i++) 

        { 

            result[i] = (i < v1.size ? v1[i] : 0) % (i < v2.size ? v2[i] : 1); 

        } 

        return result; 

    } 

  

    public static VectorULong operator %(VectorULong v, ulong scalar) 

    { 

        if (scalar == 0) 

        { 

            throw new DivideByZeroException(); 

        } 

        VectorULong result = new VectorULong(v.size); 

        for (uint i = 0; i < v.size; i++) 

        { 

            result[i] = v[i] % scalar; 

        } 

        return result; 

    } 

  

    // Overloading bitwise operators 

    public static VectorULong operator |(VectorULong v1, VectorULong v2) 

    { 

        uint maxSize = Math.Max(v1.size, v2.size); 

        VectorULong result = new VectorULong(maxSize); 

        for (uint i = 0; i < maxSize; i++) 

        { 

            result[i] = (i < v1.size ? v1[i] : 0) | (i < v2.size ? v2[i] : 0); 

        } 

        return result; 

    } 

  

    public static VectorULong operator |(VectorULong v, ulong scalar) 

    { 

        VectorULong result = new VectorULong(v.size); 

        for (uint i = 0; i < v.size; i++) 

        { 

            result[i] = v[i] | scalar; 

        } 

        return result; 

    } 

  

    public static VectorULong operator ^(VectorULong v1, VectorULong v2) 

    { 

        uint maxSize = Math.Max(v1.size, v2.size); 

        VectorULong result = new VectorULong(maxSize); 

        for (uint i = 0; i < maxSize; i++) 

        { 

            result[i] = (i < v1.size ? v1[i] : 0) ^ (i < v2.size ? v2[i] : 0); 

        } 

        return result; 

    } 

  

    public static VectorULong operator ^(VectorULong v, ulong scalar) 

    { 

        VectorULong result = new VectorULong(v.size); 

        for (uint i = 0; i < v.size; i++) 

        { 

            result[i] = v[i] ^ scalar; 

        } 

        return result; 

    } 

  

    public static VectorULong operator &(VectorULong v1, VectorULong v2) 

    { 

        uint maxSize = Math.Max(v1.size, v2.size); 

        VectorULong result = new VectorULong(maxSize); 

        for (uint i = 0; i < maxSize; i++) 

        { 

            result[i] = (i < v1.size ? v1[i] : 0) & (i < v2.size ? v2[i] : 0); 

        } 

        return result; 

    } 

  

    public static VectorULong operator &(VectorULong v, ulong scalar) 

    { 

        VectorULong result = new VectorULong(v.size); 

        for (uint i = 0; i < v.size; i++) 

        { 

            result[i] = v[i] & scalar; 

        } 

        return result; 

    } 

  

    public static VectorULong operator >>(VectorULong v1, int shift) 

    { 

        VectorULong result = new VectorULong(v1.size); 

        for (uint i = 0; i < v1.size; i++) 

        { 

            result[i] = v1[i] >> shift; 

        } 

        return result; 

    } 

  

    public static VectorULong operator <<(VectorULong v1, int shift) 

    { 

        VectorULong result = new VectorULong(v1.size); 

        for (uint i = 0; i < v1.size; i++) 

        { 

            result[i] = v1[i] << shift; 

        } 

        return result; 

    } 

  

    // Overloading comparison operators 

    public static bool operator ==(VectorULong v1, VectorULong v2) 

    { 

        if (v1.size != v2.size) 

            return false; 

        for (uint i = 0; i < v1.size; i++) 

        { 

            if (v1[i] != v2[i]) 

                return false; 

        } 

        return true; 

    } 

  

    public static bool operator !=(VectorULong v1, VectorULong v2) 

    { 

        return !(v1 == v2); 

    } 

  

    public static bool operator >(VectorULong v1, VectorULong v2) 

    { 

        if (v1.size != v2.size) 

            return false; 

        for (uint i = 0; i < v1.size; i++) 

        { 

            if (v1[i] <= v2[i]) 

                return false; 

        } 

        return true; 

    } 

  

    public static bool operator >=(VectorULong v1, VectorULong v2) 

    { 

        if (v1.size != v2.size) 

            return false; 

        for (uint i = 0; i < v1.size; i++) 

        { 

            if (v1[i] < v2[i]) 

                return false; 

        } 

        return true; 

    } 

  

    public static bool operator <(VectorULong v1, VectorULong v2) 

    { 

        if (v1.size != v2.size) 

            return false; 

        for (uint i = 0; i < v1.size; i++) 

        { 

            if (v1[i] >= v2[i]) 

                return false; 

        } 

        return true; 

    } 

  

    public static bool operator <=(VectorULong v1, VectorULong v2) 

    { 

        if (v1.size != v2.size) 

            return false; 

        for (uint i = 0; i < v1.size; i++) 

        { 

            if (v1[i] > v2[i]) 

                return false; 

        } 

        return true; 

    } 

} 