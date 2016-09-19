using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

public class GameLoad : MonoBehaviour {

	private MySqlConnection connection = new MySqlConnection();
	private MySqlCommand cmd;
	private MySqlDataReader mdr;
	string query;
	string question, ans, shuffled;
	GameObject quest;
	Text test;
	System.Random rnd = new System.Random();

	void Start ()
	{
		quest = GameObject.Find ("Question");
		test = quest.GetComponent<Text> ();

		System.Random rnd = new System.Random ();
		int num = rnd.Next (1, 13);

		connection.ConnectionString = "Server=127.0.0.1;Database=quiztwist;Uid=root;Pwd=;Pooling=";
		try
		{
			connection.Open();

			query = "select * from science where ID = '"+num.ToString()+"'";
			cmd = new MySqlCommand(query, connection);
			mdr = cmd.ExecuteReader();

			int count = 0;

			while (mdr.Read())
			{
				count++;

				if (count == 1)
				{
					question = mdr["Qstn"].ToString();
					ans = mdr["Answr"].ToString();
					test.text = question;
					shuffled = new string(ans.OrderBy(r => rnd.Next()).ToArray());
					Debug.Log(ans);
				}
			}
		}
		catch (Exception q)
		{
			Debug.Log (q);
		}
		finally
		{
			connection.Close();
		}
	}
}
