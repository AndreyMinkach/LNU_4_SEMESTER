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

Edge::Edge()
{

}

Edge::Edge(size_t FirstPoint, size_t SecondPoint, size_t Weight)
    : mFirstPoint(FirstPoint),mSecondPoint(SecondPoint), mWeight(weight())
{}
