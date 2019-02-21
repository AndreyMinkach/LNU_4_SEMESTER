#ifndef EDGE_H
#define EDGE_H
#include <iostream>

class Edge
{
private:
    size_t mFirstPoint;
    size_t mSecondPoint;
    size_t mWeight;
public:
    Edge();
    Edge(size_t FirstPoint, size_t SecondPoint, size_t Weight);
    size_t firstPoint() const;
    void setFirstPoint(const size_t &firstPoint);
    size_t secondPoint() const;
    void setSecondPoint(const size_t &secondPoint);
    size_t weight() const;
    void setWeight(const size_t &weight);

    void initialization();
    void initialization(size_t FirstPoint, size_t SecondPoint, size_t Weight);
};

#endif // EDGE_H
