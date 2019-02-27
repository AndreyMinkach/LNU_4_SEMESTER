#include <iostream>
class Vector3D; // сначала говорим компилятору, что класс с именем Vector3D существует


class Point3D
{
private:
    double m_x, m_y, m_z;

public:
    Point3D(double x = 0.0, double y = 0.0, double z = 0.0)
        : m_x(x), m_y(y), m_z(z)
    {

    }

    void print()
    {
        std::cout << "Point(" << m_x << " , " << m_y << " , " << m_z << ")\n";
    }

    void moveByVector(const Vector3D &v); // чтобы мы могли использовать Vector3D здесь
       // Примечание: Мы не можем определить эту функцию здесь, так как Vector3D еще не был определен (компилятор увидит только его предварительное объявление)
};

class Vector3D
{
private:
    double m_x, m_y, m_z;

public:
    Vector3D(double x = 0.0, double y = 0.0, double z = 0.0)
        : m_x(x), m_y(y), m_z(z)
    {

    }

    void print()
    {
        std::cout << "Vector(" << m_x << " , " << m_y << " , " << m_z << ")\n";
    }

    friend void Point3D::moveByVector(const Vector3D &v); // Point3D::moveByVector() теперь является другом класса Vector3D
};

// Теперь, когда Vector3D был определен, мы можем определить функцию Point3D::moveByVector()
void Point3D::moveByVector(const Vector3D &v)
{
    m_x += v.m_x;
    m_y += v.m_y;
    m_z += v.m_z;
}

int main()
{
    Point3D p(3.0, 4.0, 5.0);
    Vector3D v(3.0, 3.0, -2.0);

    p.print();
    p.moveByVector(v);
    p.print();

    return 0;
}
