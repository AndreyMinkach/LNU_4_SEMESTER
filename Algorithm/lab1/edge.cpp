#include "edge.h"

size_t Edge::firstPoint() const
{
    return mFirstPoint;
}

void Edge::setFirstPoint(const size_t &firstPoint)
{
    mFirstPoint = firstPoint;
}

size_t Edge::secondPoint() const
{
    return mSecondPoint;
}

void Edge::setSecondPoint(const size_t &secondPoint)
{
    mSecondPoint = secondPoint;
}

size_t Edge::weight() const
{
    return mWeight;
}

void Edge::setWeight(const size_t &weight)
{
    mWeight = weight;
}

void Edge::initialization(size_t firstPoint, size_t secondPoint, size_t weight)
{
    mFirstPoint = firstPoint;
    mSecondPoint = secondPoint;
    mWeight = weight;
}

Edge::Edge()
{
    initialization(0,0,0);
}

Edge::Edge(size_t firstPoint, size_t secondPoint, size_t weight)
{
    initialization(firstPoint, secondPoint, weight);
}
