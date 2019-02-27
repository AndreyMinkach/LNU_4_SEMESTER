#include<iostream>
 using namespace std;
int a,b,u,v,n,i,j,ne=1;
int visited[10]={0},mi,mincost=0,cost[10][10];

int main()
{
    int path[100]={0};
    int path_index=0;


    cout<<"Enter number of vertices "; cin>>n;
    cout<<"Enter the matrix of adjacency \n";



    for(i=1;i<=n;i++)
    for(j=1;j<=n;j++)
    {
        cin>>cost[i][j];
        if(cost[i][j]==0)
            cost[i][j]=999;
    }
    visited[1]=1;
    cout<<"\n";

    while(ne < n)
    {mi =999;
        for(int i=1;i<=n;i++)
        for(j=1;j<=n;j++)
        if(cost[i][j]< mi)
        if(visited[i]!=0)
        {
            mi=cost[i][j];
            a=u=i;
            b=v=j;
        }
        if(visited[u]==0 || visited[v]==0)
        {
            path[path_index]=b;
            path_index++;
            ne++;
            mincost+=mi;
            visited[b]=1;

        }
        cost[a][b]=cost[b][a]=999;
    }


    cout<<"\n";

    cout<<1<<" --> ";
    for (int i=0;i<n-1;i++)
    {
      cout<<path[i];
      if (i<n-2) cout<<" --> ";
    }

    cout<<"\n Min price "<<mincost;

    return 0;
}
