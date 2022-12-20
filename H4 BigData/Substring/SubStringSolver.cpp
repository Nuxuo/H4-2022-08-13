#include <iostream>
#include <vector>
#include <time.h>
using namespace std;

char chars[] = {'a','a','a','a','a'};
std::vector<char> _array;
std::vector<char> lookup_array;
std::vector<char> result;
int index_start = 0;
int _len = 50;

int WinMain() {
    cout << endl << endl;

    srand(time(0));
    for (int i = 0; i < _len; i++){
        char x = 97 + rand() % 26;
        _array.push_back(x);
        cout << x << " ";
    }

    // for (int i = 0; i < _len; i++){
    //     _array.push_back(chars[i]);
    //     cout << chars[i] << " ";
    // }


    for(int x = 0; x < _len; x ++) {
        for(char y : lookup_array) {
            if(_array[x] == y){
                if(lookup_array.size() > result.size()){
                    result.clear();
                    index_start = x;
                    for(char z : lookup_array){
                        result.push_back(z);
                    }
                }
                lookup_array.clear();
            }
        }
        lookup_array.push_back(_array[x]);
    }

    if(result.size() == 0){
        for(char z : _array)
            result.push_back(z);
            index_start = result.size();
    }

    cout << endl;
    for (int i = 0; i < index_start - result.size(); i++)
        cout << "  ";
    for(char i : result) 
        cout << i << " ";
    cout << endl << endl << endl;

    return 0;
}