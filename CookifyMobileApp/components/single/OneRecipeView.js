import { CardStyleInterpolators } from '@react-navigation/stack';
import React, {useEffect, useState, useRef} from 'react';
import {SafeAreaView, View, FlatList, StyleSheet, Text, StatusBar, Image, Animated, TouchableOpacity} from 'react-native';
import axios from 'axios';

const api_url = "https://cookifyv2.azurewebsites.net/api/recipes"

const OneRecipeView = (props) => {
    const {recipe, backAnimFunc}= props.route.params;
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

    const deleteRecipe = () => {
      axios.delete(`${api_url}/${recipe.id}`).then(res => {
        console.log(res);
      })
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
                <Text>Id: <Text style={styles.innerText}> {recipe.id}</Text></Text>
                <Text>Creator Id: <Text style={styles.innerText}>{recipe.creatorId}</Text></Text>
                <Text>Description: <Text style={styles.innerText}>{recipe.description}</Text></Text>
                <Text>Rating: <Text style={styles.innerText}>{recipe.rating}</Text></Text>
                <Text>Tag: <Text style={styles.innerText}>{recipe.tag}</Text></Text>
                <TouchableOpacity onPress={deleteRecipe}>
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
      marginTop: 100,
      color: "#ff0000"
    }
});
  
export default OneRecipeView;