// answer 959443 is too low
// answer 2115281 is to high

#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;

string path = "C://Users/brygo/OneDrive/Pulpit/7.txt";

class Dir
{
public:
    string name;
    int Fsize;

public:
    Dir(string inp)
    {
        name = inp.substr(5, inp.size() - 5);
        Fsize = 0;
    }
    void addValue(string inp)
    {
        if (isdigit(inp[1]))      // ---- test if it is a file size line
        {
            cout << "Add " << this->name << " : " << inp << endl;
            this->Fsize += stoi(inp.substr(0, inp.find(" ")));
        }
    }
    int checkDir(string Cname)
    {
        string Clinia;
        fstream Cplik;
        Cplik.open(path, ios::in);

        // Find start of that catalog
        while (Cplik.eof() != true)
        {
            if (Clinia.size() >= 5 && Clinia.substr(5, Clinia.size() - 5) == Cname)break;
            getline(Cplik, Clinia);
        };

        // Loop until you are in the catalog o subfolders
        while (Cplik.eof() != true)
        {
            getline(Cplik, Clinia);
            if (Clinia.substr(0, 5) == "$ cd " && Clinia != "$ cd ..")break;
            if (isdigit(Clinia[1])) this->addValue(Clinia);
            if (Clinia.substr(0, 4) == "dir ")this->checkDir(Clinia.substr(4, Clinia.size() - 3));
        };
        Cplik.close();
        return 0;
    }
};
int main()
{

    string linia;
    fstream plik;

    int maxSize = 100000;
    int answer = 0;
    vector <Dir> myFiles;

    plik.open(path, ios::in);
    if (plik.good() == true)
    {
        do
        {
            // Create list of directories
            getline(plik, linia);
            if (linia.substr(0, 5) == "$ cd " && linia.substr(5, 2) != "..")
            {
                myFiles.push_back(Dir(linia));
            };
        } while (!plik.eof());

        plik.close();

        // Check all of that directories size
        for (int i = 0; i <= myFiles.size() - 1; i++)
        {
            myFiles[i].checkDir(myFiles[i].name);
        }
    }


    // display results
    for (int i = 0; i <= myFiles.size() - 1; i++)
    {
        cout << myFiles[i].name << " " << myFiles[i].Fsize << " || ";
    }
    cout << endl;


    // display results
    for (int i = 0; i <= myFiles.size() - 1; i++)
    {

        if (myFiles[i].Fsize <= maxSize) answer += myFiles[i].Fsize;
    }
    cout << endl;

    cout << "answer is: " << answer << " razem katalogow: " << myFiles.size() << endl;
    return 0;
}
