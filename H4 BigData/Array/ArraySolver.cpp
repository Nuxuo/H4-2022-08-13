#include <iostream>
#include <vector>
#include <time.h>
using namespace std;

int _len = 50;
int * _array;
int target;
int value;
bool _solved = false;
std::vector<int> math;

int * ArrayCreator(){
    srand(time(0));
    static int _array [50];
    for (int i = 0; i < _len; i++)
        _array[i] = (rand()%200)-100;
    return _array;
}

bool Solver(int _x){
    for (int x = _x; x < _len - 1 ; x++){
        if(_array[x] + value == target && _array[x] != target){
            math.push_back(_array[x]);
            return true;
        }
        else{
            value = value + _array[x];
            math.push_back(_array[x]);
            if(Solver(x + 1)){
                return true;
            }
            value = value - _array[x];
            math.pop_back();
            if(Solver(x + 1)){
                return true;
            }
        }
    }
    return _solved;
}

int WinMain() {
    _array = ArrayCreator();
    target = _array[0];

    if(Solver(1)){
        cout << "Solved!"<< endl << endl;
        for(int i : math) 
            cout << i << " + ";
        cout << " = " << target << endl << endl;
    }
    else
        cout << "Failed to solve." << endl << endl;


    for (int i = 0; i < _len; i++)
        cout << _array[i] << ",";
    cout << endl;

    delete [] _array;
    return 0;
}