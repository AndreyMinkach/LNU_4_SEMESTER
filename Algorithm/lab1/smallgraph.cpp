#include "smallgraph.h"


SubGraph::SubGraph()
    : mParent(0), mRank(0)
{

}

SubGraph::SubGraph(size_t parent, size_t rank)
    :mParent(parent),mRank(rank)
{

}

size_t SubGraph::parent() const
{
    return mParent;
}

void SubGraph::setParent(const size_t &parent)
{
    mParent = parent;
}

size_t SubGraph::rank() const
{
    return mRank;
}

void SubGraph::setRank(const size_t &rank)
{
    mRank = rank;
}

