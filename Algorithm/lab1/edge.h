#ifndef EDGE_H
#define EDGE_H

#include <iostream>

class Edge
{
public:
    Edge();
    Edge(size_t firstPoint, size_t secondPoint, size_t weight);

    size_t firstPoint() const;
    void setFirstPoint(const size_t &firstPoint);

    size_t secondPoint() const;
    void setSecondPoint(const size_t &secondPoint);

    size_t weight() const;
    void setWeight(const size_t &weight);

    void setAllValues(size_t firstPoint, size_t secondPoint, size_t weight);
    void showInfo();

private:
    size_t mFirstPoint;
    size_t mSecondPoint;
    size_t mWeight;

    void initialization(size_t firstPoint, size_t secondPoint, size_t wight);
};
#endif // EDGE_H
