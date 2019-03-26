#ifndef SMALLGRAPH_H
#define SMALLGRAPH_H


#include <iostream>
class SubGraph
{
public:
    SubGraph();
    SubGraph(size_t parent, size_t rank);
    size_t parent() const;
    void setParent(const size_t &parent);

    size_t rank() const;
    void setRank(const size_t &rank);

private:
    size_t mParent;
    size_t mRank;
};

#endif // SMALLGRAPH_H
