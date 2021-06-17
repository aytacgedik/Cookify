import { CardStyleInterpolators } from '@react-navigation/stack';
import React, {useEffect, useState, useRef} from 'react';
import {SafeAreaView, View, FlatList, StyleSheet, Text, StatusBar, Image, Animated, TouchableOpacity} from 'react-native';
import axios from 'axios';

const api_url = "https://cookifyv2.azurewebsites.net/api/recipes"

const OneRecipeView = (props) => {
    const {navigation, recipe, backAnimFunc}= props.route.params;
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

    const parseIngredients = (ingredients) => {
      let str = "";
        for(let i = 0; i < ingredients.length; i++) {
            if (i < ingredients.length - 1) {
                str = str + ingredients[i].name + ",";
            } else {
                str = str + ingredients[i].name;
            }
        }
        return str;
  }
    
    const updateRecipe = () => {
      navigation.push("UpdateRecipe", {navigation: navigation, recipe: recipe})
    }
    
    const deleteRecipe = () => {
      axios.delete(`${api_url}/${recipe.id}`).then(res => {
        console.log(res);
      }).then(response => navigation.push("RecipesList"))
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
                <Text>Ingredients: <Text style={styles.innerText}>{parseIngredients(recipe.ingredients)}</Text></Text>
                <TouchableOpacity onPress={updateRecipe}>
                  <Text style={styles.updateText}>Update</Text>
                </TouchableOpacity>
                
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
      paddingTop: 30,
      color: "#ff0000"
    },
    updateText: {
      paddingTop: 30,
      color: "#0000ff"
    }
});
  
export default OneRecipeView;