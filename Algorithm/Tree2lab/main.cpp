#include <iostream>

struct Tree
{
    int val;
    Tree *left;
    Tree *right;
};

Tree *makeNode(int val)
{
    Tree *tempTree = new Tree;
    tempTree->left = tempTree->right = nullptr;
    tempTree->val = val;
    return tempTree;
}

void setLeft(Tree *aTree, int val)
{
    aTree->left = makeNode(val);
}

void setRight(Tree *aTree, int val)
{
    aTree->right = makeNode(val);
}

void insert(Tree *aTree, int val)
{
    while (1)
    {
        if(val <= aTree->val)
        {
            if(aTree->left != nullptr)
            {
                aTree = aTree->left;
            }
            else
            {
                setLeft(aTree, val);
                break;
            }
        }
        else
        {
            if(aTree->right != nullptr)
            {
                aTree = aTree->right;
            }
            else
            {
                setRight(aTree, val);
                break;
            }
        }
    }
}
void infix(Tree *p)
{
    if (p != NULL)
    {
        infix(p->left);
        std::cout<<p->val<<std::endl;
        infix(p->right);
    }
}
void prefix(Tree *p)
{
    if (p != NULL)
    {
        std::cout<<p->val<<std::endl;
        prefix(p->left);
        prefix(p->right);
    }
}
void postfix(Tree *p)
{
    if (p != NULL)
    {
        postfix(p->left);
        postfix(p->right);
        std::cout<<p->val<<std::endl;
    }

}

void inTrav(Tree *aTree)
{
    if(aTree->left != nullptr)
        inTrav(aTree->left);
        std::cout<<"Value is = "<<aTree->val<<std::endl;
    if(aTree->right != nullptr)
        inTrav(aTree->right);
}
int main()
{
    int firstPoint, tempPoint, howMuchPoints;
    std::cout<<"Enter first point and cont of points = ";
    std::cin >> firstPoint >> howMuchPoints;

    Tree *myTree = makeNode(firstPoint);
    for (int i = 0; tempPoint != 111; i++)
    {
        std::cin>>tempPoint;
        insert(myTree, tempPoint);
    }

    infix(myTree);
    //postfix(myTree);
    //prefix(myTree);
}
