import { ThemeProvider } from '@react-navigation/native';
import { HeaderStyleInterpolators } from '@react-navigation/stack';
import React, { useEffect, useState, useRef } from 'react';
import { SafeAreaView, View, FlatList, StyleSheet, Text, StatusBar, Image, Animated, LogBox, ScrollView} from 'react-native';
import {TextInput, TouchableOpacity} from 'react-native-gesture-handler';
import { Value } from 'react-native-reanimated';
import { withSafeAreaInsets } from 'react-native-safe-area-context';

LogBox.ignoreLogs([
    'Non-serializable values were found in the navigation state',
    'VirtualizedLists should never be nested inside plain ScrollViews with the same orientation - use another VirtualizedList-backed container instead.'
  ]);
const renderListItem = (item, navigation, rotate, fadeOut, backAnimFunc) => (
    <View style={styles.item}>
        <TouchableOpacity onPress={()=> { fadeOut(); rotate(); setTimeout(()=>{navigation.push("Ingredient", {ingredient: item,backAnimFunc: backAnimFunc});}, 700) }}>
            <Text style={styles.title}>{item.name}</Text>
        </TouchableOpacity>
    </View>

);

const IngredientsList = ( {navigation} ) => {
    const [isLoading, setLoading] = useState(true);
    const [ingredients, setIngredients] = useState([]);
    const fadeAnim = useRef(new Animated.Value(0)).current;
    const rotateAnim = useRef(new Animated.Value(0)).current;
    const [searchText, setSearchText] = useState('');

    const fadeIn = () => {
        Animated.timing(fadeAnim, {
          toValue: 1,
          duration: 700,
          useNativeDriver: true
        }).start();
    }

    const fadeOut = () => {
        Animated.timing(fadeAnim, {
            toValue: 0,
            duration: 700,
            useNativeDriver: true  
        }).start();
    }

    const rotate = () => {
        Animated.timing(rotateAnim, {
            toValue: 1,
            duration: 700,
            useNativeDriver: true
          }).start();
    }
    const rotateBack = () =>{
        Animated.timing(rotateAnim, {
            toValue: 0,
            duration: 700,
            useNativeDriver: true
        }).start();
    }
    const backAnimFunc = () => {
        fadeIn();
        rotateBack();
    }

    const fetchData = (text) => {
        setLoading(true);
        var url;
        if (searchText.length === 0) {
            url = `https://cookifyv2.azurewebsites.net/api/ingredient`;
        } else {
            url = `https://cookifyv2.azurewebsites.net/api/ingredients/search?query=${searchText}`;
        }
        console.log(url);
        fetch(url)
        .then((response) => response.json())
        .then((json) => setIngredients(json))
        .then(() => {fadeIn();})
        .catch((error) => console.error(error))
        .finally(() => setLoading(false));
    }
    
    useEffect(() =>{
        fetchData();
    }, [searchText]);

    return (
        <ScrollView style={styles.container}>     
            <View>
                <TextInput style={styles.textInput} value={searchText} onChangeText={ text => {
                    if (text === undefined) {
                        setSearchText('');
                    } else {
                        setSearchText(text);
                    }
                }} />
                {isLoading ? <Text style={styles.textLabel}>Loading...</Text> :
                <Animated.View style={{opacity: fadeAnim,
                transform:[
                    {
                        rotateY: rotateAnim.interpolate({
                            inputRange: [0, 1],
                            outputRange: ["0deg", "180deg"],
                        }),
                    },
                ],
                }}>
                    <FlatList
                        data={ingredients.length > 0 ? ingredients.slice(0, ingredients.length) : []}
                        renderItem={({item}) => renderListItem(item, navigation, rotate, fadeOut, backAnimFunc)}
                        keyExtractor={item => JSON.stringify(item.id)}
                        onRefresh={() => fetchData()}
                        refreshing={isLoading}
                    />
                </Animated.View>}
            </View>
        </ScrollView>
    );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    marginTop: (StatusBar.currentHeight || 0),
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
  textInput: {
    fontSize: 15,
    color: 'green',
    borderWidth: 1,
    borderColor: 'black',
    margin: 15,
    paddingLeft: 10
  },
  textLabel: {
      marginLeft: 15,
      marginBottom: 5
  }
});

export default IngredientsList;
