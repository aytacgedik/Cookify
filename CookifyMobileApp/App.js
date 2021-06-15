import { StatusBar } from 'expo-status-bar';
import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import { createStackNavigator } from '@react-navigation/stack'
import { NavigationContainer } from '@react-navigation/native'

import CooksList from './components/lists/CooksList'
import IngredientsList from './components/lists/IngredientsList'
import RecipesList from './components/lists/RecipesList'

import OneCookView from './components/single/OneCookView'
import OneIngredientView from './components/single/OneIngredientView'
import OneRecipeView from './components/single/OneRecipeView'

import CreateRecipeView from './components/single/CreateRecipeView'

import StartPage from './components/StartPage'
const Stack = createStackNavigator();

export default function App() {
  return (
    <NavigationContainer style={styles.container}>
      <Stack.Navigator initialRouteName="StartPage">
        <Stack.Screen name = "StartPage" component={StartPage}/>

        <Stack.Screen name = "CooksList" component={CooksList} />
        <Stack.Screen name = "Cook">
          {props => <OneCookView {...props}/>}
        </Stack.Screen>

        <Stack.Screen name = "IngredientsList" component={IngredientsList} />
        <Stack.Screen name = "Ingredient">
          {props => <OneIngredientView {...props}/>}
        </Stack.Screen>

        <Stack.Screen name = "RecipesList" component={RecipesList} />
        <Stack.Screen name = "Recipe">
          {props => <OneRecipeView {...props}/>}
        </Stack.Screen>
        <Stack.Screen name = "CreateRecipe">
          {props => <CreateRecipeView {...props}/>}
        </Stack.Screen>


      </Stack.Navigator> 
    </NavigationContainer>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
