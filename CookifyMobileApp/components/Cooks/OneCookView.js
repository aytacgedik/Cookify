import { CardStyleInterpolators } from '@react-navigation/stack';
import axios from 'axios';
import React, {useEffect, useState, useRef} from 'react';
import {SafeAreaView, View, FlatList, StyleSheet, Text, StatusBar, Image, Animated, TouchableOpacity} from 'react-native';

const api_url = "https://cookifyv2.azurewebsites.net/api/users"

const OneCookView = (props) => {
    const {navigation, cook, backAnimFunc}= props.route.params;
    const rotateAnimDetail = useRef(new Animated.Value(0)).current;

    const rotate = () => {
      Animated.timing(rotateAnimDetail, {
          toValue: 1,
          duration: 700,
          useNativeDriver: true
        }).start();
    }
    useEffect(() =>{
      rotate();
      return () => {
        backAnimFunc();
      }
    }, []);

    const updateCook = () => {
      navigation.push("UpdateCook", {navigation: navigation, cook: cook})
    }

    const deleteCook = () => {
      axios.delete(`${api_url}/${cook.id}`).then(res => {
        console.log(res);
      }).then(response => navigation.push("CooksList"))
    }


    return (
            <Animated.View style={{ margin:20,
              transform:[
                {
                    rotateY: rotateAnimDetail.interpolate({
                        inputRange: [0, 1],
                        outputRange: ["90deg", "0deg"],
                    }),
                },
            ],
            }}>
                <Text>Id: <Text style={styles.innerText}> {cook.id}</Text></Text>
                <Text>Name: <Text style={styles.innerText}> {cook.name}</Text></Text>
                <Text>Surname: <Text style={styles.innerText}>{cook.surname}</Text></Text>
                <Text>Email: <Text style={styles.innerText}>{cook.email}</Text></Text>
                <Text>Verified: <Text style={styles.innerText}>{cook.verified.toString()}</Text></Text>
                <Text>Admin: <Text style={styles.innerText}>{cook.admin.toString()}</Text></Text>
                
                <TouchableOpacity onPress={updateCook}>
                  <Text style={styles.updateText}>Update</Text>
                </TouchableOpacity>
                
                <TouchableOpacity onPress={deleteCook}>
                  <Text style={styles.deleteText}>Delete</Text>
                </TouchableOpacity>
            </Animated.View>
    )

}
const styles = StyleSheet.create({
    container: {
      flex: 1,
      marginTop: StatusBar.currentHeight || 0,
      marginLeft: 20,
    },
    item: {
      backgroundColor: '#00bfff',
      padding: 20,
      marginVertical: 8,
      marginHorizontal: 16,
    },
    title: {
      fontSize: 24,
    },
    flag: {
      height: 64,
      width: 64
    },
    innerText: {
      fontWeight: 'bold'
    },
    deleteText: {
      paddingTop: 30,
      color: "#ff0000"
    },
    updateText: {
      paddingTop: 30,
      color: "#0000ff"
    }
});
  
export default OneCookView;