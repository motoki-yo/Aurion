//References
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mono.Data.Sqlite;
public class Usuario : MonoBehaviour
{
    public string nick, senha;
    public char exc;
    public int id, pontos;

    public void setNick(string n){this.nick = n;}
    public string getNick(){return this.nick;}
    public void setSenha(string s){this.senha = s;}
    public string getSenha(){return this.senha;}
    public void setExc(char e){this.exc = e;}
    public char getExc(){return this.exc;}
    public void setPontos(int p){this.pontos = p;}
    public int getPontos(){return this.pontos;}
    public void setId(int i){this.id = i;}
    public int getId(){return this.id;}

    


}