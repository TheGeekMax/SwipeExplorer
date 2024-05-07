using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labyrinth{
    private int width;
    private int height;

    private SimpleCell[,] cells;

    public Labyrinth(int width, int height){
        this.width = width;
        this.height = height;

        this.cells = new SimpleCell[width, height];
        for(int i = 0; i < width; i++){
            for(int j = 0; j < height; j++){
                cells[i, j] = new SimpleCell(i, j);
            }
        }
    }

    private List<SimpleCell> GetNeighbors(SimpleCell cell){
        List<SimpleCell> neighbors = new List<SimpleCell>();

        int x = cell.x;
        int y = cell.y;

        //test if not visited
        if(x > 0 && !cells[x - 1, y].visited){
            neighbors.Add(cells[x - 1, y]);
        }
        if(x < width - 1 && !cells[x + 1, y].visited){
            neighbors.Add(cells[x + 1, y]);
        }
        if(y > 0 && !cells[x, y - 1].visited){
            neighbors.Add(cells[x, y - 1]);
        }
        if(y < height - 1 && !cells[x, y + 1].visited){
            neighbors.Add(cells[x, y + 1]);
        }

        return neighbors;
    }

    public void Generate(){
        Stack<SimpleCell> stack = new Stack<SimpleCell>();
        SimpleCell current = cells[width / 2, height / 2];
        current.visited = true;
        stack.Push(current);

        while(stack.Count > 0){
            List<SimpleCell> neighbors = GetNeighbors(current);

            if(neighbors.Count > 0){
                SimpleCell next = neighbors[Random.Range(0, neighbors.Count)];
                stack.Push(next);

                if(next.x > current.x){
                    cells[current.x, current.y].wallRight = false;
                    cells[next.x, next.y].wallLeft = false;
                }
                if(next.x < current.x){
                    cells[current.x, current.y].wallLeft = false;
                    cells[next.x, next.y].wallRight = false;
                }
                if(next.y > current.y){
                    cells[current.x, current.y].wallDown = false;
                    cells[next.x, next.y].wallUp = false;
                }
                if(next.y < current.y){
                    cells[current.x, current.y].wallUp = false;
                    cells[next.x, next.y].wallDown = false;
                }

                next.visited = true;
                current = next;
            }else{
                current = stack.Pop();
            }
        }
    }

    public SimpleCell[,] GetCells(){
        return cells;
    }

    public SimpleCell GetCell(int x, int y){
        return cells[x, y];
    }
}
